     public SqlConnection Connection { get; set; }
            public AccessDataBase()
            {
                Connection = new SqlConnection("Data Source=.;Initial Catalog=NewDB;Integrated Security=True");
    
            }
    
            public DataSet readDB(string selectquery)
            {
                SqlCommand cmd = new SqlCommand(selectquery);
                using (Connection)
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = Connection;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
