    public static void DatabaseFilePut(MemoryStream fileToPut, OracleConnection con)
        {
            try
            {
                //int varID = 0;
                //var file = fileToPut.ToArray();
                const string preparedCommand =
                    @"INSERT INTO user_account_statement (statement_id,session_key,login_id,user_id,account_number,from_date,to_date,ipaddress,create_date_time,STATEMENT_FILE)VALUES(1073,'fe79e0345986b5a439c26f731234868b53f877366f529',2335,'204254','108142',to_date('2014-08-23 16:45:06','yyyy-mm-dd hh24:mi:ss'),to_date('2014-08-23 16:45:06','yyyy-mm-dd hh24:mi:ss'),'106.79.126.249',to_date('2014-08-23 16:45:06','yyyy-mm-dd hh24:mi:ss')," + " :ssfile)";
                using (var sqlWrite = new OracleCommand(preparedCommand, con))
                {
                    sqlWrite.BindByName = true;
                    var blobparameter = new OracleParameter
                    {
                        OracleDbType = OracleDbType.Blob,
                        ParameterName = "ssfile",
                        Value = fileToPut.ToArray()
                    };
                    sqlWrite.Parameters.Add(blobparameter);
                    sqlWrite.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
