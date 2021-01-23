    public bool InsertSecure(String tableName, Dictionary<String, String> data)
    {
        // table name can not contains space
        if (tableName.Contains(' ')) { return false; }
        String columns = "";
        String values = "";
        Boolean returnCode = true;
        foreach (KeyValuePair<String, String> val in data)
        {
            columns += String.Format(" {0},", val.Key.ToString());
            // all values as parameters
            values += String.Format(" @{0},", val.Key.ToString());
        }
        columns = columns.Substring(0, columns.Length - 1);
        values = values.Substring(0, values.Length - 1);
        try
        {
            // setup your connection here
            // (connection is probably set in your original ExecuteNonQuery)
            SQLiteConnection cnn = new SQLiteConnection(); 
            cnn.Open();
            SQLiteCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            // prepare insert command based on data
            cmd.CommandText = String.Format("insert into {0} ({1}) values ({2})",
                tableName, columns, values);
            
            // now your command looks like:
            // insert into table_name (columnA, columnB) values (@columnA, @columnB)
            // next we can set values for any numbers of columns
            // over parameters to prevent SQL injection
            foreach (KeyValuePair<String, String> val in data)
            {
                // safe way to add parameter
                cmd.Parameters.Add(
                    new SQLiteParameter("@" + val.Key.ToString(), val.Value));
                // you just added for @columnA parameter value valueA
                // and so for @columnB in this foreach loop
            }
            // execute new insert with parameters
            cmd.ExecuteNonQuery();
            // close connection and set return code to true
            cnn.Close();
            returnCode = true;
        }
        catch (Exception fail)
        {
            MessageBox.Show(fail.Message);
            returnCode = false;
        }
        return returnCode;
    }
