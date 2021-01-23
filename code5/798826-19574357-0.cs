    LinkedList<class1> myList = new LinkedList<class1>
        (new[] { new class1(1), new class1(2), new class1(3) });
    LinkedListNode<class1> myItem = myList.First;
    Console.WriteLine(myItem.Next.Value.Id); // 2
    public class class1
    {
        public int Id { get; set; }
        public class1(int id)
        {
            this.Id = id;
        }
    }
