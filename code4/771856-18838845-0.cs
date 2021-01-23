    var filename = System.IO.Path.GetTempFileName();
    
    // Assuming that fileBytes is a byte[] containing what you read from your database        
    System.IO.File.WriteAllBytes(filename, fileBytes);
    var connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
    // Do your work on excel
    using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connection))
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "SELECT * FROM [Sheet1$]";
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    System.Diagnostics.Debug.WriteLine(rdr["ColumnName"]);
                }
            }
        }
        conn.Close();
    }
    //Cleanup
    System.IO.File.Delete(filename);
