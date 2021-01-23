    public static void SaveBook(Model.Book myBook)
    {
        using (var ctx = new BookDBContext())
        {
            ctx.Books.Add(myBook);
            ctx.Entry(myBook).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
