        public static bool DeleteBefore(LinkedListNode n)
        {
            LinkedListNode prev = front;
            while (prev.data!=n.data)
            {
                prev = prev.next;
            }
            front = prev;
            return true;
        }
             LinkedListNode myList = new LinkedListNode(5);
            myList.AppendToTail(6);
            myList.AppendToTail(7);
            myList.AppendToTail(8);
            // Now the list is 5->6->7->8
            front = myList;// Added this line
            Console.Write("Before deletion: ");
            PrintList(myList); // 5->6->7->8->null 
            LinkedListNode deletedNode = myList;
            int val = 5;
            while (deletedNode.data != val)
            {
                deletedNode = deletedNode.next;
            }
            Console.Write("After deletion: ");
            if (DeleteBefore(deletedNode))
            {
                myList = front;//Added this line
                PrintList(myList);
            }
