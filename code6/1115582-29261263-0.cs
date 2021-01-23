    static void Main(string[] args)
    {
        using (OracleConnection conn = new OracleConnection("Data Source=tnsname;User Id=zzzz;Password=xxxx"))
        {
            using (OracleCommand cmd = new OracleCommand("SELECT * from CONTRACT", conn))
            {
                conn.Open();
                using(IDataReader reader = cmd.ExecuteReader())
                {
                    .....
                }
            }
        }
    }
