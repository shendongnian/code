        public static LinkedListNode DeleteBefore(LinkedListNode n)
        {
            LinkedListNode prev = front;
            while (prev.data!=n.data)
            {
                prev = prev.next;
            }
            front = prev;
            
            return front;
        }
             LinkedListNode myList = new LinkedListNode(5);
            myList.AppendToTail(6);
            myList.AppendToTail(7);
            myList.AppendToTail(8);
            // Now the list is 5->6->7->8
            Console.Write("After deletion: ");
            PrintList(DeleteBefore(deletedNode));
          }
