    public class BookRepository : IBookRepository
    {
        public bool Add(Book book)
        {
            try
            {
                DemoData.books.Add(book);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool BorrowBook(BorrowedBooks details)
        {
            try
            {
                DemoData.borrowedBooks.Add(details);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
