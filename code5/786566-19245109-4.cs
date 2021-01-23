    var columnNames = new List<string>();
    foreach (DataColumn column in dt.Columns)
    {
        columnNames.Add(column.ColumnName);
    }
    
    var xlContent = new XElement("Content", from row in dt.AsEnumerable()
                                            select new XElement("Row", from columnName in columnNames
                                                                       select new XElement(columnName, row[columnName]))).ToString();
