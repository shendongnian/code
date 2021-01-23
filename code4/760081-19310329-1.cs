    using (var conn = new SqlConnection("Data Source=localhost;Initial Catalog=temp;User ID=sa"))
    {
        conn.Open();
        DataTable dt = new DataTable();
        dt.Columns.Add("SomeInt", typeof(Int32));
        dt.Rows.Add(new Object[] { 3 });
        var command = conn.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "MyProc";
        command.Parameters.Add(new SqlParameter("@Arg1", dt));
        object returnValue = command.ExecuteScalar();
    }
