                using (OleDbConnection conn = new OleDbConnection())
                {
                    DataTable dt = new DataTable();
                    string Import_FileName = Server.MapPath(file_path);
                    //Import_FileName = System.IO.Path.GetDirectoryName(file_path);
                    string fileExtension = Path.GetExtension(Import_FileName);
                    if (fileExtension == ".xlsx")
                        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                    using (OleDbCommand comm = new OleDbCommand())
                    {
                        comm.CommandText = "Select * from [Sheet1$]";
                        comm.Connection = conn;
                        using (OleDbDataAdapter da = new OleDbDataAdapter())
                        {
                            da.SelectCommand = comm;
                            da.Fill(dt);
                                                        }
                    }
                }
            }
