    foreach (string column in colFields)
    {
        DataColumn datacolumn = new DataColumn(column, typeof(decimal));
        datacolumn.AllowDBNull = true;
        csvData.Columns.Add(datacolumn);
    }
    while (!csvReader.EndOfData)
    {
        string[] fieldData = csvReader.ReadFields();
        DataRow addedRow = csvData.Rows.Add();
        for (int i = 0; i < fieldData.Length; i++)
        {
            decimal value;
            if(decimal.TryParse(fieldData[i].Trim(), out value))
                addedRow.SetField<decimal?>(i, value);
            else
                addedRow.SetField<decimal?>(i, null);
        }
    }
