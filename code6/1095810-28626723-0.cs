    private DataTable ConvertListToDataTable(List<List<object>> list)
    {
        DataTable table = new DataTable();
        for (int i = 0; i < MyList.Count; i++)
        {
            table.Columns.Add(MyList[i], typeof(string));
        }
        table.Columns.Add("", typeof(object));
        // Add rows data
        List<object[]> tObj = new List<object[]>();
        for (int i = 0; i < list.Count; i++)
        {
            tObj.Add((object[])(list[i].ToArray()));
        }
        for (int i = 0; i < list.Count; i++)
        {
            table.Rows.Add(tObj[i]);
        }
        return table;
    }
