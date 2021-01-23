    [TestMethod]
    public void SpecialDistinctTest()
    {
        // create a table
        var table = new DataTable();
        var uniqueFields = new List<string> { "ID", "antenna", "size" };
        var otherFields = new List<string> { "kpi1value", "kpi2value" };
        foreach (var uniqueField in uniqueFields)
        {
            table.Columns.Add(new DataColumn(uniqueField, typeof(Int32)));
        }
        foreach (var otherField in otherFields)
        {
            table.Columns.Add(new DataColumn(otherField, typeof(Int32)));
        }
        // add some items.
        AddRows(table);
        DataTable resultTable = SpecialDistinct(table, uniqueFields, otherFields);
        // check results from the table table
    }
    private void AddRows(DataTable table)
    {
        DataRow row = table.NewRow();
        row.ItemArray = new object[] { 22, 33, 40, 20, DBNull.Value };
        table.Rows.Add(row);
        row = table.NewRow();
        row.ItemArray = new object[] { 33, 45, 50, 30, DBNull.Value };
        table.Rows.Add(row);
        row = table.NewRow();
        row.ItemArray = new object[] { 22, 33, 40, DBNull.Value, 55 };
        table.Rows.Add(row);
        row = table.NewRow();
        row.ItemArray = new object[] { 33, 45, 50, DBNull.Value, 30 };
        table.Rows.Add(row);
    }
