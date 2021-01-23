    OleDbConnection MyConnection;
	DataSet DtSet;
	OleDbDataAdapter MyCommand;
	MyConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tbFileName.Text + ";Extended Properties=Excel 12.0;");
	Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application(); 
    //get the workbook
	Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Open(tbFileName.Text); 
	//get the first worksheet
    Microsoft.Office.Interop.Excel.Worksheet wSheet = excelBook.Sheets.Item[1]; 
    //reference the name of the worksheet from the identified spreadsheet item
	MyCommand = new OleDbDataAdapter("select * from [" + wSheet.Name + "$]", MyConnection);
