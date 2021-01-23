    {
        const string query = "SELECT name FROM NewTable";
        var command = new SqlCommand(){CommandText = query, CommandType = System.Data.CommandType.Text,Connection=sqlConn};
        var dataAdapter = new SqlDataAdapter() { SelectCommand = command };
        DataTable dataTable = new DataTable("Names");
        dataAdapter.Fill(dataTable);
        int count = dataTable.Rows.Count; 
        int index = new Random().Next(count);
        DataRow d = dataTable.Rows[index];
        Console.WriteLine(d[0]);
    }
