    string oradb = "Data Source=ORCL;User Id=hr;Password=hr;";
    using(OracleConnection conn = new OracleConnection(oradb))
    using(OracleCommand cmd = new OracleCommand())
    {
       conn.Open();
       cmd.Connection = conn;
       cmd.CommandText = "select * from departments";
       cmd.CommandType = CommandType.Text;
       using(OracleDataReader dr = cmd.ExecuteReader())
       {
           dr.Read();
           label1.Text = dr.GetString(0);
       }
    }
