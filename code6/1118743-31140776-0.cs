        #region generate SQL Update Script
        static void da_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            string sqlCommand = e.Command.CommandText;
            for (int i = 0; i < sqlCommand.Length; i++)
            {
                string substring = "";
                string paramvalue = "";
                int check = 0;
                int index = 0;
                substring = sqlCommand.Substring(i, 1);
                if (substring == "@")
                {
                    if (Int32.TryParse(sqlCommand.Substring(i + 3, 1), out check))
                    {
                        index = Convert.ToInt32(sqlCommand.Substring(i + 2, 2));
                        paramvalue = e.Command.Parameters[Convert.ToInt32(sqlCommand.Substring(i + 2, 2)) - 1].Value.ToString();
                        sqlCommand = sqlCommand.Remove(i, 4);
                    }
                    else
                    {
                        index = Convert.ToInt32(sqlCommand.Substring(i + 2, 1));
                        paramvalue = e.Command.Parameters[index - 1].Value.ToString();
                        sqlCommand = sqlCommand.Remove(i, 3);
                    }
                    sqlCommand = sqlCommand.Insert(i, paramvalue);
                }
            }
            sw.WriteLine(sqlCommand);
            sw.Flush();
        }
        #endregion generate SQL Update Script
