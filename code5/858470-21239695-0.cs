    SqlDataAdapter dataAdpater = new SqlDataAdapter(
      "SELECT temptesttableid, Age, Name FROM TempTestTable WHERE Name = @Name",
      connection);
    DataTable testTable = new DataTable();
    // note that you should use an available csv-parser instead
    foreach (string line in File.ReadAllLines(path))
    { 
        string[] columns = line.Split(new char[]{'\t'}, StringSplitOptions.None);
        if(columns.Length >= 2)
        {
            string name = columns[0].Trim();
            string ageStr = columns[1].Trim();
            int age;
            if (int.TryParse(ageStr, out age))
            {
                dataAdpater.SelectCommand.Parameters.AddWithValue("@Name", name);
                int rowsAdded = dataAdpater.Fill(testTable);
                if (rowsAdded == 0)
                {
                    testTable.Rows.Add(name, age);
                }
                else
                {
                    // update values?
                }
            }
        }
    }
    dataAdpater.Update(testTable);
