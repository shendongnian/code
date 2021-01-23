    using (SqlConnection sqlConn = new SqlConnection(@"Data Source=BBATRIDIP\SQLSERVER2008R2;Initial Catalog=test;Integrated Security=True"))
                {
                    string query = String.Format(@"SELECT [FilePath],[FileName],[FileData] FROM [TestTable]");
                    SqlCommand cmd = new SqlCommand(query, sqlConn);
                    cmd.Connection.Open();
    
                    ZipFile zip = new ZipFile();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] data = (byte[])reader["FileData"];
                            System.IO.MemoryStream memStream = new System.IO.MemoryStream(data);
                            string strFile = reader["FilePath"].ToString() + "\\" + reader["FileName"].ToString();
                            ZipEntry ze = zip.AddEntry(strFile, memStream);
    
                        }
                    }
                    zip.Save(@"e:\MyCustomZip.zip");
                }
