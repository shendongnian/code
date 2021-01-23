    using (TransactionScope scope = new TransactionScope())
    {
    using ( var db= new dbEntity)
    {
    //query code 
     Foreach ( var item in query)
    {
     //program logic 
     db.savechange();
    }
    }
    scope.complete();
    }
