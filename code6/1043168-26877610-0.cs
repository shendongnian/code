                    int count;
                    OleDbConnection conn = new OleDbConnection();
                    conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=access.mdb";
                    conn.Open();
                    OleDbCommand cmmd = new OleDbCommand("SELECT * FROM probe", conn);
                    using (OleDbDataReader myReader = cmmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(myReader);
                        count = dt.Rows.Count;
                        lblCount.Text = count.ToString();
                        conn.Close();
                    }
