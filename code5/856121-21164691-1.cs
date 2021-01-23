     SqlCommand getDataPath = new SqlCommand("select physical_name from sys.database_files;", baseConnection); // get default path where the sqlserver saves files
                string temp = getDataPath.ExecuteScalar().ToString();
                temp = temp.Replace(temp.Split('\\').Last(), string.Empty);
                StringBuilder sqlScript = new StringBuilder(Scripts.CreateDatabase); //CreateDatabase could be in ressources
                ///The @@@@ are used to replace the hardcorededpath in your script
                sqlScript.Replace("@@@@MAINDATAFILENAME@@@@", string.Concat(temp, "test.mdf"));
                sqlScript.Replace("@@@@LOGDATAFILENAME@@@@", string.Concat(temp, "test_log.ldf"));
                string[] splittedScript = new string[] { "\r\nGO\r\n" }; //remove GO
                string[] commands = sqlScript.ToString().Split(splittedScript,
                  StringSplitOptions.RemoveEmptyEntries);
