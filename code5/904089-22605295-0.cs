    var sqlMetaData = new[] 
    {
      new SqlMetaData("ID", SqlDbType.Int, true, false, SortOrder.Unspecified, -1),
      new SqlMetaData("Name", SqlDbType.NVarChar, 50)
    };
    
    var sqlRecords = new HashSet<SqlDataRecord>();
    var sqlRec = new SqlDataRecord(sqlMetaData);
    
    sqlRec.SetString(1, "Nyan");
    sqlRecords.Add(sqlRec);
    
    var conn = new SqlConnection("connstring");
    try
    {
        conn.Open();           
    
        using (var cmd = new SqlCommand("tests", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            var param = new SqlParameter("@tbl", SqlDbType.Structured) { Value = sqlRecords };
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error in tests.");
        Console.WriteLine(ex.Message);
    }
    finally
    {
        if (conn.State == ConnectionState.Open)
            conn.Close();
    }
