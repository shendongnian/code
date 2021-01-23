    private void update_gic_attendances()
    {
        using(OleDbConnection cn = new OleDbConnection(....your connection string...))
        using(OleDbCommand com = new OleDbCommand(....., cn))
        {
             cn.Open();
             .....
             using(OleDbDataReader dr1 = com.ExecuteReader())
             {
                while(dr1.Read())
                {
                    using(OleDbCommand com2 = new OleDbCommand(...., cn);
                    using(OleDbDataReader dr2 = com2.ExecuteReader())
                    {
                       ....
                       if(dr2.HasRows)
                       {
                            using(OleDbCommand com3 = new OleDbCommand(....., cn)
                            {
                               ....
                              com3.ExecuteNonQuery();
                            }
                       }
                       else
                       {
                            using(OleDbCommand com3 = new OleDbCommand(....., cn))
                            {
                                com3.ExecuteNonQuery();
                            }
                       }
                    }
                }
            }
        }
    }
