    string names = "Excel table: \n";
    foreach (DataColumn dc in excelDataTable.Columns)
    {
        names += dc.ColumnName+"\n";
    }
    
    names += "Sql table: \n";
    foreach (DataColumn dc in sqlDataTable.Columns)
                    {
                        names += dc.ColumnName+"\n";
                    }
    MessageBox.Show(names);
