    public void FindVenue()
    {
       using (var trans = new TransactionScope()) {
           CreateCity();
           // some code to add your venue...
           // ...
           context.SaveChanges();
           trans.Commit();
       }
    }
