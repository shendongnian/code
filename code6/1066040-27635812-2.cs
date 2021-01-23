    class Program
    {
            static void Main(string[] args)
            {
                LinkedList<Item> Books = new LinkedList<Item>();
                Item book1 = new Item(101, "Avatar: Legend of Korra", 13.50);
                Item book2 = new Item(102, "Avatar: Legend of Aang", 10.60);
                Books.AddFront(book1);
                Books.AddFront(book2);
    
                Books.DisplayAll();
            }
    }
