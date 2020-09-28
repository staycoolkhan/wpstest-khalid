using System;

namespace wpstest_khalid
{
    class Program
    {
        static void Main(string[] args)
        {
            WPSList linkedList = new WPSList();
            linkedList.AppendLast(10);
            linkedList.AppendLast(20);
            linkedList.AppendLast(30);
            linkedList.AppendLast(40);
            linkedList.AppendLast(45);
            linkedList.AppendLast(50);
            linkedList.AppendLast(55);
            linkedList.AppendStart(1);
            linkedList.AppendStart(5);
            linkedList.AppendMiddle(40, 45);

            linkedList.ListNode();
            Console.WriteLine("Total number of node:" + linkedList.nodeCounter);
            Console.ReadLine();
        }


    }

    public class WPSList
    {
        private Node startNode = null;
        private Node endNode = null;
        public int nodeCounter;

        //A node for the linked list.
        public class Node
        {
            public int value;
            public Node next;

            public Node(int value)
            {
                this.value = value;
                this.next = null;
            }
        }

        private Node CreateNode(int value)
        {
            nodeCounter++;
            return new Node(value);
        }

        public void AppendLast(int value)
        {
            if (startNode == null)
            {
                startNode = CreateNode(value);
                endNode = startNode;
            }
            else
            {
                Node node = CreateNode(value);
                endNode.next = node;
                endNode = node;
            }
        }

        public void AppendStart(int value)
        {
            Node node = CreateNode(value);
            node.next = startNode;
            startNode = node;
        }

        public void AppendMiddle(int insertAfter, int newValue)
        {
            Node node = startNode;
            while (node != null)
            {
                if (node.value == insertAfter)
                {
                    Node newNode = CreateNode(newValue);
                    newNode.next = node.next;
                    node.next = newNode;
                    break;
                }
                node = node.next;
            }
        }

        public void DeleteFromStart()
        {
            if (startNode != null)
            {
                nodeCounter--;
                startNode = startNode.next;
            }
        }

        public void DeleteFromEnd()
        {

            if (startNode == null)
            {
                return;
            }

            if (startNode == endNode)
            {
                nodeCounter--;
                startNode = endNode = null;
                return;
            }

            Node node = startNode;
            while (node.next.next != null)
            {
                node = node.next;
            }
            node.next = null;
            endNode = node;
            nodeCounter--;
        }

        public void ListNode()
        {
            Node node = startNode;
            while (node != null)
            {
                Console.WriteLine("-->" + node.value);
                node = node.next;
            }
        }

        public void DeleteParticularNode(int deleteValue)
        {
            if (startNode == null)
            {
                return;
            }

            if (startNode == endNode)
            {
                if (startNode.value == deleteValue)
                {
                    startNode = endNode = null;
                    nodeCounter--;
                }
                else
                {
                    Console.WriteLine("Value not found");
                }
                return;
            }

            if (startNode.value == deleteValue)
            {
                DeleteFromStart();
                return;
            }

            Node node = startNode;
            while (node.next != null)
            {
                if (node.next.value == deleteValue)
                {
                    node.next = node.next.next;
                    nodeCounter--;
                    break;
                }
                node = node.next;
            }
        }

    }
}
