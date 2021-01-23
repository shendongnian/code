                ConnectionManager cm;
                System.Data.SqlClient.SqlConnection sqlConn;
                cm = Dts.Connections["<connection name>"];//should be an ADO .NET connection
                sqlConn = (System.Data.SqlClient.SqlConnection)cm.AcquireConnection(Dts.Transaction);
                    foreach (string dirpath in Directory.EnumerateDirectories("<Folder Location>"))
                    {
                        //Sql Parameters object creation
                        SqlParameter SQLFileNameName = new SqlParameter("@FileName", SqlDbType.VarChar,200);
                        SqlParameter SQLFileLocation = new SqlParameter("@FileLoc", SqlDbType.VarChar, 200);
                        //Assign value to SQL parameter
                        SQLFileLocation.Value = dirpath;
                        foreach (string path in Directory.EnumerateFiles(dirpath))
                        {
                            //Assign value to SQL parameter
                            SQLFileNameName.Value = Path.GetFileName(path);
                            
                            //Populate to a SQL Table
                            SqlCommand sqlCmd = new SqlCommand("INSERT INTO [dbo].[<Table Name>] (FileName,FileLocation) VALUES (@FileName,@FileLoc)", sqlConn);
                            //Assign Parameters to script
                            sqlCmd.Parameters.Add(SQLFileNameName);
                            sqlCmd.Parameters.Add(SQLFileLocation);
                            //Execute SQL Command
                            sqlCmd.ExecuteNonQuery();
                            //Clear the parameters and the set the object to NULL
                            sqlCmd.Parameters.Clear();
                            sqlCmd = null;
                        }
                    }
