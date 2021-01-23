    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Question7
    {
        public class LinkedListNode
        {
            public LinkedListNode next = null;
            public int data;
            public LinkedListNode(int d) { data = d; }
            public void AppendToTail(int d)
            {
                LinkedListNode end = new LinkedListNode(d);
                LinkedListNode n = this;
                while (n.next != null) { n = n.next; }
                n.next = end;
            }
        }
    
        class Program
        {
            #region DeleteAFter
            public static bool DeleteAfter(LinkedListNode n)
            {
                if (n == null || n.next == null)
                {
                    return false; // Failure
                }
    
                LinkedListNode next = n.next;
                n.next = next.next;
                return true;
            }
            #endregion
    
            static LinkedListNode front;
            #region DeleteBefore
            public static bool DeleteBefore(LinkedListNode root, LinkedListNode n)
            {
                LinkedListNode prev = root;
                LinkedListNode curr = n;
    
                // we're iterating from the root, looking if the next node is the one we're looking for.
                while (prev.next != null && curr.data != prev.next.data)
                {
                    prev = prev.next;
                }
    
                // if we found it
                if (prev.next != null && curr.data == prev.next.data)
                {
                    // we're rewiring our list. we can also prev.next = curr.next;
                    prev.next = prev.next.next;
                    return true;
                }
    
                return false;
            }
    
            #endregion
    
            static void PrintList(LinkedListNode list)
            {
                while (list != null)
                {
                    Console.Write(list.data + "->");
                    list = list.next;
                }
                Console.WriteLine("null");
            }
            static void Main(String[] args)
            {
                LinkedListNode myList = new LinkedListNode(5);
                myList.AppendToTail(6);
                myList.AppendToTail(7);
                myList.AppendToTail(8);
                // Now the list is 5->6->7->8
    
                Console.Write("Before deletion: ");
                PrintList(myList); // 5->6->7->8->null 
    
                LinkedListNode deletedNode = myList;
    
                int val = 7;
    
                while (deletedNode.data != val)
                {
                    deletedNode = deletedNode.next;
                }
    
                Console.Write("After deletion: ");
                if (DeleteBefore(myList, deletedNode))
                    PrintList(myList);
                Console.Read();
            }
        }
    }
