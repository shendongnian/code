    private void fillCombo(string query, string name, ComboBox c)
    {
        MySqlCommand cmdReader;
        MySqlDataReader myReader;
    
        try
        {
            cmdReader = new MySqlCommand(query, conn);
            myReader = cmdReader.ExecuteReader();
    
            var table = myReader.GetSchemaTable();
    
            foreach (DataColumn column in Table.Columns)
            {
                string s = column.ColumnName;
              
                if (!c.Items.Contains(s))
                {
                    c.Items.Add(s);
                }
            }
    
            myReader.Close();
        }
        catch (Exception e) { Console.WriteLine("Unable to load data from database"); }
    }
