    class Program
    {
        static void Main(string[] args)
        {
            LinkedList singlyLinkedList = new LinkedList();
            singlyLinkedList.AddToLinkedList(4);
            singlyLinkedList.AddToLinkedList(5);
            singlyLinkedList.AddToLinkedList(7);
            singlyLinkedList.AddToLinkedList(2);
            singlyLinkedList.AddToLinkedList(1);
            singlyLinkedList.AddToLinkedList(10);
            singlyLinkedList.DisplayAllItems();
            Console.ReadLine();
        }
    }
