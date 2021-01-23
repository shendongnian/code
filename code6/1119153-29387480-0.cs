    using (var con = new OleDbConnection(myConnectionString))
    {
        con.Open();
        using (var cmd = new OleDbCommand())
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "loginQuery";
            cmd.Parameters.Add("prmUsername", OleDbType.VarWChar).Value = "eric";
            cmd.Parameters.Add("prmPassword", OleDbType.VarWChar).Value = "abcdefg";
            using (OleDbDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    Console.WriteLine("Row found: ID = {0}", rdr["ID"]);
                }
                else
                {
                    Console.WriteLine("Row not found.");
                }
            }
        }
    }
