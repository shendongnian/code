    List<myObject> myCollection = new List<myObject>
    Guid identifierKey = Guid.NewGuid();
    //Do your bulk insert where all the rows inserted have the identifierKey
    //set on the new column. In this example you would create a data table based
    //off the myCollection object.
    //Identifier is a column specifically for matching a group of rows to a sql  
    //bulk copy command
    var myAddedRows = myDbContext.DatastoreRows.AsNoTracking()
                .Where(d => d.Identifier == identiferKey)
                .ToList();
     for (int i = 0; i < myAddedRows.Count ; i++)
     {
        var savedRow = myAddedRows[i];
        var inMemoryRow = myCollection[i];
        int generatedId = savedRow.Id;
       
       //Now you know the generatedId for the in memory object you could set a
       // a property on it to store the value
       inMemoryRow.GeneratedId = generatedId;
     }
   
