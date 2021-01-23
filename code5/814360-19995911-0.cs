    private void GetMyData()
    {
         String strCon = "Data Source=servername;Initial Catalog=databasename;uid=userid;pwd=password;Integrated Security=True;";
                        using (SqlConnection sqlCon = new SqlConnection(strCon))
                        {
                            String strCmd = "select PartNumber,PartName,BeginingStok from Part";
                            using (SqlCommand sqlcommand = new SqlCommand(strCmd, sqlCon))
                            {
                                sqlCon.Open();
                                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlcommand))
                                {
                                    DataSet ds = new DataSet();
                                    sqlAdapter.Fill(ds);
                                    dataGridView1.DataSource = ds.Tables[0];
                                }
                            }
                        }
    }
