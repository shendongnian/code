    ...
    .GetTestCases(delegate(string sheet, DataRow row, int rowNum)
    {
        var testDataArgs = new Dictionary<string, object>();
        foreach (DataColumn column in row.Table.Columns)
        {
            testDataArgs[column.ColumnName] = row[column];
        }
        
        var testName = sheet + rowNum;
        return new TestCaseData(testDataArgs).SetName(testName);
    }
