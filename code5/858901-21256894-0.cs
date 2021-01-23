    string connectionString = ....;
    SqlDataAdapter  adapter = new SqlDataAdapter("Select * From Cats", connectionString);
    // The command builder will generate the Add, Update and Delete commands
    // based on the select command
    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
    DataTable testTable = new DataTable("Cats");
    adapter.Fill(testTable);  // retrieve all existing rows
    // Add each record from recordList
    foreach (var record in recordList)
    {
        // TODO - Handle duplicates
        testTable.Rows.Add(
            record.UniqueCatName,
            record.Forename,
            record.Surname
        );
    }
    adapter.Update(testTable);
