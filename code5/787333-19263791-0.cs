    // You can change C:\Members.xlsx to any valid path 
    // where the file is located.
    
    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;
        FONT-SIZE: 10pt; COLOR: #a31515; FONT-FAMILY: 'Courier New'">
    				Data Source=C:\Members.xlsx;Extended
        FONT-SIZE: 10pt; COLOR: #a31515; FONT-FAMILY: 'Courier New'">
    				Properties=""Excel 12.0;HDR=YES;"""; 
    // if you don't want to show the header row (first row) in the grid
    // use 'HDR=NO' in the string
    
    string strSQL = "SELECT * FROM [Sheet1$]";
    OleDbConnection excelConnection = new OleDbConnection(connectionString);
    excelConnection.Open(); // this will open an Excel file
    OleDbCommand dbCommand = new OleDbCommand(strSQL,excelConnection);
    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dbCommand);
    
    // create data table
    DataTable dTable = new DataTable();
    
    dataAdapter.Fill(dTable);
    
    // bind the datasource
    dataBingingSrc.DataSource = dTable;
    // assign the dataBindingSrc to the DataGridView
    
