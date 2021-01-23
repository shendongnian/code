    SqlDataAdapter dataAdpater = new SqlDataAdapter(
        "SELECT * FROM Cats WHERE URN = @URN", "data source=...");
    
    dataAdpater.InsertCommand = new SqlCommand("INSERT INTO Cats VALUES (@URN, @Forename, @Middlename, @Surname)", new SqlConnection("data source=..."));
    
    dataAdpater.UpdateCommand = new SqlCommand("UPDATE Cats SET Forename=@Forename, Middlename=@Middlename, Surname=@Surname WHERE URN=@URN", new SqlConnection("data source=..."));
    
    DataTable testTable = new DataTable();
    
    dataAdpater.Update(testTable);
    
    dataAdpater.SelectCommand.Parameters.Add("@URN", SqlDbType.NVarChar, 256, "URN");
    
    dataAdpater.InsertCommand.Parameters.Add("@URN", SqlDbType.NVarChar, 256, "URN");
    dataAdpater.InsertCommand.Parameters.Add("@Forename", SqlDbType.NVarChar, 256, "Forename");
    dataAdpater.InsertCommand.Parameters.Add("@Middlename", SqlDbType.NVarChar, 256, "Middlename");
    dataAdpater.InsertCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 256, "Surname");
    
    dataAdpater.UpdateCommand.Parameters.Add("@URN", SqlDbType.NVarChar, 256, "URN");
    dataAdpater.UpdateCommand.Parameters.Add("@Forename", SqlDbType.NVarChar, 256, "Forename");
    dataAdpater.UpdateCommand.Parameters.Add("@Middlename", SqlDbType.NVarChar, 256, "Middlename");
    dataAdpater.UpdateCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 256, "Surname");
    
    foreach (var record in recordList)
    {
        dataAdpater.SelectCommand.Parameters["@URN"].Value = record.URN;
        
        int rowsAdded = dataAdpater.Fill(testTable);
        if (rowsAdded == 0)
        {
            var newRow = testTable.NewRow();
    
            newRow["URN"] = record.URN;
            newRow["Forename"] = record.Forename;
            newRow["MiddleName"] = record.MiddleName;
            newRow["Surname"] = record.Surname;
    
            testTable.Rows.Add(newRow);
        }
        else
        {
            foreach (DataRow row in testTable.Rows)
            {
                if (row[1].ToString() == record.URN)
                {
                    row["Forename"] = record.Forename;
                    row["MiddleName"] = record.MiddleName;
                    row["Surname"] = record.Surname;
                }
            }
        }
    }
    
    dataAdpater.Update(testTable);
