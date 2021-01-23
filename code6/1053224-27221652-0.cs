    DataSet dataSet = new DataSet();
    DataTable customTable = new DataTable();
    DataColumn dcName = new DataColumn("Name", typeof(string));
    dcName.MaxLength= 500;
    customTable.Columns.Add(dcName);
    dataSet.Tables.Add(customTable);
