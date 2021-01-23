    cn = New OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=myTNSEntry;User ID=fakeuser;Password=abc123");
    cn.Open();
    oleDBCmd = cn.CreateCommand();
    oleDBCmd.CommandType = CommandType.StoredProcedure;
    oleDBCmd.CommandText = "ThingPackage.GetThingByID";
    oleDBCmd.Parameters.Add(new OleDbParameter("thingID", "1"));
