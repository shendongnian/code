    public static void FiletoSql(MemoryStream fileToPut, MySqlConnection con)
        {
            byte[] data = fileToPut.ToArray();
            try
            {
                const string preparedCommand =
                    @"update user_account_statement set STATEMENT_FILE=@ssfile, create_date_time=@udatetime where statement_Id=1070";
                using (var sqlWrite = new MySqlCommand(preparedCommand, con))
                {
                    sqlWrite.Parameters.Add("@ssfile", MySqlDbType.Blob);
                    sqlWrite.Parameters.Add("udatetime", MySqlDbType.DateTime);
                    
                    sqlWrite.Parameters["@ssfile"].Value = data;
                    sqlWrite.Parameters["udatetime"].Value=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    sqlWrite.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
