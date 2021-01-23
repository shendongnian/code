    var connectionString = "my connection string";
    var commandText = "INSERT INTO Person (ID, Name, Age) VALUES (?, ?, ?)";
    var parameters = new List<OleDbParameter>();
    parameters.Add(new OleDbParameter { Value = "12345" }); // id
    parameters.Add(new OleDbParameter { Value = "Joe Bloggs" }); // name
    parameters.Add(new OleDbParameter { Value = 35 }); // age
    
    Core.DataAccess.OleDb.DataInterface.DoWrite(connectionString, commandText, parameters.ToArray());
