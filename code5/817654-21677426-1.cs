    /// <summary>
    /// Creating the Linked List Class Itself. It defines the First and Last Nodes of Linked List
    /// </summary>
    public class LinkedList
    {
        public LinkedListNode First { get; set; }
        public LinkedListNode Last { get; set; }
        /// <summary>
        /// Method to Add items into the Linked List
        /// </summary>
        /// <param name="_value"></param>
        public void AddToLinkedList(object _value)
        {
            LinkedListNode node = new LinkedListNode();
            node.Value = _value;
            if (First == null)
            {
                First = node;
                Last = node;
            }
            else
            {
                Last.Next = node;
                Last = node;
            }
        }
        /// <summary>
        /// Method to display all items. We can further implement the IEnumerable interface
        /// to Yield IEnumerator Interface.
        /// </summary>
        public void DisplayAllItems()
        {
            LinkedListNode current = First;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }
