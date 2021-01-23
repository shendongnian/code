    namespace The.Correct.Namespace
    {
        public partial class Book
        {
            public static List<Book> GetQueryBooks(string query)
            {
                // Init db
                LibraryDataClassesDataContext db = new LibraryDataClassesDataContext();
                return db.Books.Where(b => b.Title.Contains(query) || b.Author.Contains(query)).ToList();
        
            } 
        }     
    }
