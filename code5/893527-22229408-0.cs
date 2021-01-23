    public static DataTable convertStringToDataTable(string data)
    {
        DataTable dataTable = new DataTable();
        bool columnsAdded = false;
        foreach(string row in data.Split('$'))
        {
            DataRow dataRow = dataTable.NewRow();
            foreach(string cell in row.Split('|'))
            {
                string[] keyValue = cell.Split('~');
                if (!columnsAdded)
                {
                    DataColumn dataColumn = new DataColumn(keyValue[0]);
                    dataTable.Columns.Add(dataColumn);
                }
                dataRow[keyValue[0]] = keyValue[1];
            }
            columnsAdded = true;
            dataTable.Rows.Add(dataRow);
        }
        return dataTable;
    }
