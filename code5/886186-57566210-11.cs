    ocn = New OracleConnection("Data Source=myTNSEntry;User ID=fakeuser;Password=abc123");
    ocn.Open();
    ocmd = ocn.CreateCommand();
    ocmd.CommandType = CommandType.StoredProcedure();
    ocmd.CommandText = "ThingPackage.GetThingByID2";
    ocmd.Parameters.Add(New OracleParameter("thingID", "1"));
    ocmd.Parameters.Add(New OracleParameter("results", OracleDbType.RefCursor, ParameterDirection.InputOutput));
    dataReader = ocmd.ExecuteReader();
