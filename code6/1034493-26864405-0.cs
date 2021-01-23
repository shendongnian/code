    public class Controller
    {
        public void DeleteBook(Book book)
        {
            // assuming that you're working on context directly and need to dispose it
            using (var context = new YourContext())
            {
                var entry = context.Entry(book);
                // Will tell you if Author navigation property is loaded
                bool isLoaded = entry.Reference(x => x.Author).IsLoaded();
                
                if (isLoaded != false)
                {
                    // do when Author navigation property is loaded
                }
                else
                {
                    // do when Author navigation property is not loaded
                }
            }
         }
    }
