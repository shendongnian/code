     class Program
        {
            static void Main(string[] args)
            {
                LinkedList list = new LinkedList();
                list.Add(new Node("first"));
                list.Add(new Node("second"));
                list.Add(new Node("third"));
                list.Add(new Node("fourth"));
                list.PrintNodes();
            }
            
        }
        public class Node
        {
            public object data;
            public Node next;
            public Node(object data)
            {
                this.data = data;
            }
        }
        public class LinkedList
        {
            private Node head;
            private Node current;
            public void Add(Node n)
            {
                if (head == null)
                {
                    head = n;
                    current = head;
                }
                else
                {
                    current.next = n;
                    current = current.next;
                }
                
            }
            public void PrintNodes()
            {
                while (head != null)
                {
    
                    Console.WriteLine(head.data);
                    head = head.next;
                   
                }
                Console.ReadLine();
            }
             
        }
