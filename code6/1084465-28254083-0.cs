    public static DataTable WriteToDataTable(string data)
    {
        DataTable dataTable = new DataTable();
        _csvHeader.ForEach((a) => dataTable.Columns.Add(a));
        using (var reader = new StringReader(data))
        {
            TextFieldParser csvParser = new TextFieldParser(reader) { HasFieldsEnclosedInQuotes = true, Delimiters = new string[] { "," } };
            while (!csvParser.EndOfData)
            {
                var dataTableRow = dataTable.NewRow();
                dataTableRow.ItemArray = csvParser.ReadFields();
                dataTable.Rows.Add(dataTableRow);
            }
        }
        return dataTable;
    }
