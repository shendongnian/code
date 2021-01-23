    public static class DemoData
    {
        static Book book1 =    new Book { Id = 1, Title = "Queen of the road", Author = "Tricia Stringer" };
        static Book book2 = new Book { Id = 2, Title = "Don't look now", Author = "Paul Jennings" };
        static Book book3 = new Book { Id = 3, Title = "Too bold to die", Author = "Ian McPhedran" };
        static Book book4 = new Book { Id = 4, Title = "The rosie project", Author = "Graeme Simson" };
        static Book book5 = new Book { Id = 5, Title = "In great spirits", Author = "Archie Barwick" };
        static Book book6 = new Book { Id = 6, Title = "The vale girl", Author = "Nelika Mcdonald" };
        static Book book7 = new Book { Id = 7, Title = "Watching you", Author = "Michael Robotham" };
        static Book book8 = new Book { Id = 8, Title = "Stillways", Author = "Steve Bisley" };
        static Borrower borrower1 = new Borrower { Id = 1, Firstname = "John", Lastname = "Smith" };
        static Borrower borrower2 = new Borrower { Id = 2, Firstname = "Mary", Lastname = "Jane" };
        static Borrower borrower3 = new Borrower { Id = 3, Firstname = "Peter", Lastname = "Parker" };
        static Borrower borrower4 = new Borrower { Id = 4, Firstname = "Eddie", Lastname = "Brock" };
        static BorrowedBooks borrowed1 = new BorrowedBooks { BookId = 8, Book = book8,  BorrowerId = 2, Borrower=borrower2, DateBorrowed = DateTime.Parse("01/04/2014") };
        static BorrowedBooks borrowed2 =   new BorrowedBooks {BookId = 6, Book = book6,  BorrowerId = 4, Borrower = borrower4, DateBorrowed = DateTime.Parse("08/04/2014")};
        static BorrowedBooks borrowed3 = new BorrowedBooks { BookId = 2, Book = book2, BorrowerId = 4, Borrower = borrower4, DateBorrowed = DateTime.Parse("08/04/2014") };
        static BorrowedBooks borrowed4 = new BorrowedBooks { BookId = 1, Book = book1, BorrowerId = 1, Borrower = borrower1, DateBorrowed = DateTime.Parse("26/03/2014") };
        public static List<BorrowedBooks> borrowedBooks = new List<BorrowedBooks>
            {
                borrowed1, borrowed2, borrowed3, borrowed4
            };
        public static List<Book> books = new List<Book>
            {
               book1, book2, book3, book4, book5, book6, book7, book8
            };
        private static List<Borrower> borrowers = new List<Borrower>
            {
                borrower1, borrower2, borrower3, borrower4              
            };
    }
