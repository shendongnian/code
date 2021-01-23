    public class BookComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book x, Book y)
        {
            if (x == null || y == null) return true;
            return x.BookId == y.BookId;
        }
    
        public int GetHashCode(Book obj)
        {
            if (obj == null) return 0;
            return obj.BookId;
        }
    }
----------
    var bookComparer = new BookComparer();
    var bookLookup = loans.ToLookup(l => l.book, bookComparer);
    var maxCount = bookLookup.Max(bg => bg.Count());
    IEnumerable<Book> booksWhichAppearMostOften = bookLookup
        .Where(bg => bg.Count() == maxCount)
        .Select(bg => bg.Key);
