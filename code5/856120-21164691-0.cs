    SqlCommand getDataPath = new SqlCommand("select physical_name from sys.database_files;", baseConnection);
                        string temp = getDataPath.ExecuteScalar().ToString();
                        temp = temp.Replace(temp.Split('\\').Last(), string.Empty);
                            StringBuilder sqlScript = new 
    StringBuilder(Scripts.CreateDatabase);
    ///The @@@@ are used to replace the hardcorededpath in aour script
                                sqlScript.Replace("@@@@INSERTMAINDATAFILENAMEHERE@@@@", string.Concat(temp,"test.mdf"));
                                sqlScript.Replace("@@@@INSERTLOGDATAFILENAMEHERE@@@@", string.Concat(temp, "test_log.ldf"));
                                string[] splittedScript = new string[] { "\r\nGO\r\n" };
                                string[] commands = sqlScript.ToString().Split(splittedScript,
                                  StringSplitOptions.RemoveEmptyEntries);
