    string strDSN = "DSN=MYDSN";
                string cmdText = "Insert into AccessTable (ColumnA,ColumnB) Values (?,?)";
                using (OdbcConnection cn = new OdbcConnection(strDSN))
                {
                    using (OdbcCommand cmd = new OdbcCommand(cmdText, cn))
                    {
                        cn.Open();
                        foreach (DataRow r in dt.Rows)
                        {
    cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@p1", r["ColumnA"].ToString());
                            cmd.Parameters.AddWithValue("@p2", r["ColumnB"].ToString());
    cmd.ExecuteNonQuery();
                        }
    
                    }
                }
    }
