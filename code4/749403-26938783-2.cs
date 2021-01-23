    public static DataTable Select(MySqlConnection con, string tableName, string expressionWhere)
        {
            string text = string.Format("SELECT * FROM {0} WHERE {1};", tableName, expressionWhere);
            MySqlDataAdapter cmd = new MySqlDataAdapter(text, con);
            DataTable table = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            try
            {
                cmd.Fill(table);
            }
            catch (Exception){}
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return table;
        }
