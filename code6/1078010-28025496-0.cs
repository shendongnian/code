    var command = new SqlCommand("SELECT [Price],[Mark],[Type],[Code],[Series],[Rating],[Description],[Comments]FROM "+database+" ORDER BY CAST(ID AS INT) ", connection);
    List<object[]> allData = new List<object[]>();
    SqlDataReader reader = command.ExecuteReader();
    if (reader.HasRows)
    {
        while (reader.Read())
        {
            object[] rowData = new object[8]; // 8 because you're loading from a table with 8 columns
            for (var i = 0; i < rowData.Length; i++)
            {
                rowData[i] = reader.GetObject(i);
            }
            allData.Add(rowData);
        }
    }
    // Congratulations, you now have a collection containing all the data from your database.
    // At this point, you'll want to sort on one of the column (Loop through every row in the allData list, and compare position 0 or 1 or whatever data you want.
