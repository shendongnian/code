        DatabaseObjects = new List<MyDataObject>();
        // Create command
        var cmd = new MySqlCommand(query, _connection);
        MySqlDataReader dataReader = cmd.ExecuteReader();
        // Read the data and store it in a list
        while (dataReader.Read())
        {
            MyDataObject newRow = new MyDataObject();
            newRow.No = (dataReader["dNo"] + "");
            newRow.Date = (dataReader["pDate"] + "");
            newRow.Rent = (dataReader["pRent"] + "");
            newRow.Status = (dataReader["status"] + "");
            list.Add(newRow);
        }
