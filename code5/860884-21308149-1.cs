    using (DBEntities ctx = new DBEntities())
    {
        // Explicitly open the context connection yourself - to help prevent connection pooling / sharing
        // The connection will automatically be closed once exiting the using statement,  
        // but it won't hurt to put a ctx.Connection.Close(); after everything inside the using statement.
        ctx.Connection.Open();
        // Do Stuff
        // If necessary ctx.SaveChanges();
        // Not necessary but you could put a ctx.Connection.Close() here, for readability if nothing else.
    }
