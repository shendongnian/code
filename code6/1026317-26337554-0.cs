    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();
        const string insertQuery = @"
    INSERT INTO dbo.Suspension
    (pallet_position, processing_pallet_pkey, datetime_created, datetime_updated,
    [this.created_by], [this.updated_by]) 
    OUTPUT INSERTED.pkey VALUES
    (1, 2, '20141013 16:27:25.000', '20141013 16:27:25.000', 2, 2), 
    (2, 2, '20141013 16:27:25.000', '20141013 16:27:25.000', 2, 2), 
    (3, 2, '20141013 16:27:25.000', '20141013 16:27:25.000', 2, 2), 
    (4, 2, '20141013 16:27:25.000', '20141013 16:27:25.000', 2, 2);";
        // via datatable
        DataTable dt = new DataTable();
        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
        using (var insertedOutput = cmd.ExecuteReader())
        {
            dt.Load(insertedOutput);
        }
        Console.WriteLine(dt.Rows.Count); // 4
        // via manual read
        var list = new List<int>();
        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
        using (var insertedOutput = cmd.ExecuteReader())
        {
            while(insertedOutput.Read())
            {
                list.Add(insertedOutput.GetInt32(0));
            }
        }
        Console.WriteLine(list.Count); // 4
        // via dapper
        var ids = conn.Query<int>(insertQuery).ToList();
        Console.WriteLine(ids.Count); // 4
    }
