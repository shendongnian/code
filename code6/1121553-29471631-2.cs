    private void button2_Click(object sender, EventArgs e)
            {
                using (SqlConnection sqlConn = new SqlConnection(@"Data Source=BBATRIDIP\SQLSERVER2008R2;Initial Catalog=test;Integrated Security=True"))
                {
                    string query = String.Format(@"SELECT [FilePath],[FileName],[FileData] FROM [TestTable]");
                    SqlCommand cmd = new SqlCommand(query, sqlConn);
                    cmd.Connection.Open();
    
                    System.IO.MemoryStream memStream = null;
                    ZipFile zip = new ZipFile();
                    zip.MaxOutputSegmentSize = 1024 * 1024; // 1MB each segment size would be
                    // the above line would split zip file into multiple files and each file
                    //size would be 1MB
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] data = (byte[])reader["FileData"];
                            memStream = new System.IO.MemoryStream(data);
                            string strFile = reader["FilePath"].ToString() + "\\" + reader["FileName"].ToString();
                            ZipEntry ze = zip.AddEntry(strFile, memStream);
                        }
                    }
                    zip.Save(@"e:\MyCustomZip.zip");
                    memStream.Dispose();
                    MessageBox.Show("Job Done");
                    // here u can save the zip in memory stream also there is a overload insteaa of saving in HD
                }
            }
