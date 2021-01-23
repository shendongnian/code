    public class Book
    {
    	public  int Id { get; set; }
    	public string Title { get; set; }
    	public double Price { get; set; }
    }
    public void TestBook()
	{
		var books= new List<Book>();
		// to add a book
		books.Add(new Book { Id = 1, Title = "War and Peace", Price = 30.12});
		books.Add(new Book { Id = 2, Title = "Learn C# in 60 seconds", Price = 20.73 });
		books.Add(new Book { Id = 3, Title = "The Bible", Price = 10.56 });
		books.Add(new Book { Id = 4, Title = "How to become rich", Price = 44.12 });
		// to remove a book using an index
        // note the list index starts at 0 base, deletes Learn c#.... book
		books.RemoveAt(1); 
		// to remove a book using an instance
		var book = books.Find(b => b.Id.Equals(4));
		books.Remove(book);
		// to display all books titles
		books.ForEach(b => Console.WriteLine(b.Title));
	}
    
