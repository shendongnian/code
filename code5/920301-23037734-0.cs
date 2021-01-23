     public static class DataStore
	{
	    private static List<Book> books = new List<Book>
            {
                new Book { Id = 1, Title = "Queen of the road", Author = "Tricia Stringer", BorrowedBooks = new List<BorrowedBooks>{  new BorrowedBooks {BookId = 1, BorrowerId = 1, DateBorrowed = DateTime.Parse("26/03/2014")}} },
                new Book { Id = 2, Title = "Don't look now", Author = "Paul Jennings" },
                new Book { Id = 3, Title = "Too bold to die", Author = "Ian McPhedran" },
                new Book { Id = 4, Title = "The rosie project", Author = "Graeme Simson" },
                new Book { Id = 5, Title = "In great spirits", Author = "Archie Barwick" },
                new Book { Id = 6, Title = "The vale girl", Author = "Nelika Mcdonald" },
                new Book { Id = 7, Title = "Watching you", Author = "Michael Robotham" },
                new Book { Id = 8, Title = "Stillways", Author = "Steve Bisley" },
            };
			
		private static List<BorrowedBooks> borrowedBooks = new List<BorrowedBooks>
            {
                new BorrowedBooks {BookId = 8, Book = new Book { Id = 8, Title = "Stillways", Author = "Steve Bisley" },   BorrowerId = 2,  DateBorrowed = DateTime.Parse("01/04/2014")},
                new BorrowedBooks {BookId = 6, BorrowerId = 4, DateBorrowed = DateTime.Parse("08/04/2014")},
                new BorrowedBooks {BookId = 2, BorrowerId = 4, DateBorrowed = DateTime.Parse("08/04/2014")},
                new BorrowedBooks {BookId = 1, BorrowerId = 1, DateBorrowed = DateTime.Parse("26/03/2014")},
            };
			
		private static List<Borrower> borrowers = new List<Borrower>
            {
                new Borrower { Id = 1, Firstname = "John", Lastname = "Smith" },
                new Borrower { Id = 2, Firstname = "Mary", Lastname = "Jane" },
                new Borrower { Id = 3, Firstname = "Peter", Lastname = "Parker" },
                new Borrower { Id = 4, Firstname = "Eddie", Lastname = "Brock" },
            };
			
		public static List<Book> Books { get { return books; } }
		public static List<BorrowedBooks> BorrowedBooks { get { return borrowedBooks; } }
		public static List<Borrower> Borrowers { get { return borrowers; } }
	}
	
	public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> Search()
        {
            return DataStore.Books.Where (b => b.Author == "Paul Jennings");
        }
    }
    public class BorrowerRepository : IBorrowerRepository
    {
        public void Add(Borrower borrower)
        {
            DataStore.Borrowers.Add(borrower);
        }
    } 
