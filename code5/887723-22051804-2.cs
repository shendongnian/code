    foreach (var row in innerJoinQuery)
    {
        DataRow rowToAdd = newTable.NewRow();
        object[] items = new object[] {
            row.IntOne.ToString(),
            row.IntTwo.ToString(),
            row.StrOne.ToString(),
            row.StrTwo.ToString(),
            row.StrThree.ToString()
        };
        rowToAdd.ItemArray = items;
        newTable.Rows.Add(rowToAdd);
    }
