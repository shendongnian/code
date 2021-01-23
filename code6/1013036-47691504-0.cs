    var book = new Model.Book
    {
        BookNumber =  _book.BookNumber,
        BookName = _book.BookName,
        BookTitle = _book.BookTitle,
    };
    using (var db = new MyContextDB())
    {
        var result = db.Books.SingleOrDefault(b => b.BookNumber == bookNumber);
        if (result != null)
        {
            try
            {
                UpdateModel(book);
                db.Books.Attach(book);
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
