    class Program
    {
        class Book
        {
            public int ID;
            public string BookName;
        }
        static void Main()
        {
            var books = new List<Book> { new Book { ID = 1, BookName = "A" }, new Book { ID = 2, BookName = "B" } };
            var x = from d in books
            select new
            {
                ID = d.ID,
                BookName = d.BookName
            };
            
            string str = JsonConvert.SerializeObject(x.ToList());
            Console.WriteLine(str);
        }
    }
