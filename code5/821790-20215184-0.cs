    string sql = @"SELECT Columns 
                   FROM dbo.tableName
                   WHERE ...
                   AND ABS.AbsenceDate = @AbsenceDate";
    
    using(var con = new SqlConnection("ConnectionString"))
    using(var cmd = new SqlCommand(sql, con))
    {
        cmd.Parameters.AddWithValue("@AbsenceDate",  DateTime.Today);
        con.Open();
        using(var reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            {
                // ...
            }
        }
    }
