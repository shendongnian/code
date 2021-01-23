    public partial class Student
    {
       public IQueryable<Book> FilteredBooks
       {
          get
          {
             return this.Books.Any(b=> b.PublishedDate.Year >= 1990).AsQueryable();
          }
       }
    
    }  
