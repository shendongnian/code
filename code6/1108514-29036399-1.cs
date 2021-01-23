    DataTable originalTable = new DataTable(); 
    originalTable.Clear();
    
    originalTable.Columns.Add("Id");
    originalTable.Columns.Add("table_name");
    
    DataRow originalRow1 = originalTable.NewRow();
    originalRow1["Id"] = 1;
    originalRow1["table_name"] = "Table1";
    originalTable.Rows.Add(originalRow1);
    
    DataRow originalRow2 = originalTable.NewRow();
    originalRow2["Id"] = 2;
    originalRow2["table_name"] = "Table2";
    originalTable.Rows.Add(originalRow2);
    
    DataTable newNameTable = new DataTable(); 
    newNameTable.Clear();
    
    newNameTable.Columns.Add("table_name");
    newNameTable.Columns.Add("table_name_new");
    
    DataRow newNameRow = newNameTable.NewRow();
    newNameRow["table_name"] = "Table1";
    newNameRow["table_name_new"] = "Table1_new";
    newNameTable.Rows.Add(newNameRow);
    
    DataRow newNameRow2 = newNameTable.NewRow();
    newNameRow2["table_name"] = "Table2";
    newNameRow2["table_name_new"] = "Table2_new";
    newNameTable.Rows.Add(newNameRow2);
