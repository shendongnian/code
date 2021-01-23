    var sql = new SqlCommand("SELECT * FROM Cars; SELECT * FROM Passengers", someConnectionString);
    sql.Connection.Open();
    var reader = sql.ExecuteReader();
    while(reader.Read()){
        //do something with the Cars
    }
    reader.NextResult();
    while(reader.Read()){
        //do something with Passengers
    }
