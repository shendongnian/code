    public static DataTable WriteToDataTable(string data)
    {
        DataTable dataTable = new DataTable();
        foreach (var header in csvHeader)
            dataTable.Columns.Add(header);
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
