    DBTableRow dbrow= new DBTableRow 
    {
       CustomerID= 12000,
       Customer= "John Smith"
    };
    // Add the new object to the Customer collection.
    db.DBTableRow.InsertOnSubmit(dbrow);
     // Submit the change to the database.
     try
     {
        db.SubmitChanges();
     }
     catch (Exception e)
    {
        // perform some exception handling
    }
