    //Code under actual c# clas file where we are uploading excel.
    Excel_Common excelComm = new Excel_Common(); // object to Excel_Common class file
    
    string rangeStringwithSHeet =excelComm.GetSheetName(filepath).ToString().Trim('\'') + GetRange(excelComm.GetSheetName(filepath), excelComm.ExcelConn(filepath));
    
    queryForExcelInput = string.Format("SELECT * FROM [{0}]", rangeStringwithSHeet);
    
    Econ1 = new OleDbConnection(excelComm.ExcelConn(filepath));
    Econ1.Open();
    dataExcelInputTable = new DataTable();
    OleDbCommand oleDbCommand1 = new OleDbCommand(queryForExcelInput, Econ1);
    OleDbDataAdapter oleDbDaAdapter1 = new OleDbDataAdapter(oleDbCommand1);
    oleDbDaAdapter1.Fill(dataExcelInputTable);
