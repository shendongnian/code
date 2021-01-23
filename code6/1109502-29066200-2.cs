    for (int i = 0; i < 6; ++i)
    {
        if (i == 0)
        {
            stockTable.Columns.Add(new DataColumn(headerData[i], typeof(DateTime)));
        }
        else if (i == 1)
        {
            stockTable.Columns.Add(new DataColumn("RowNbr", typeof(int)));
        }
        else
            stockTable.Columns.Add(new DataColumn(headerData[i-1], typeof(decimal)));
    }
    //read each line and populate the data table rows
    int j = 0;
    while (reader.Peek() > -1)
    {
        line = reader.ReadLine();
        rowData = line.Split(delimeter);
        stockTable.Rows.Add(rowData[0], j++, rowData[1], rowData[2], rowData[3], rowData[4]);
    }
