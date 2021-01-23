    using (var db = new MyContextDB())
    {
        var result = db.Books.SingleOrDefault(b => b.BookNumber == bookNumber);
        if (result != null)
        {
            result.Column = "Some new value";
            db.SaveChanges();
        }
    }
