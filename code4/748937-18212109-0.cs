    String sql = "SELECT * FROM Temp WHERE Temp.collection  = '" + Program.collection + "'";
    SqlConnection conn = new SqlConnection(connString);
    using(SqlCommand cmd = new SqlCommand(sql, conn))
    {
        using(SqlDataReader rdr = cmd.ExecuteReader())
        {
            if(rdr.Read()) 
            {
                Program.defaultCollection = (String)rdr["Column1"];
                Program.someOtherVar = (String)rdr["Column2"];
            }
        }
        rdr.Close();
    }
