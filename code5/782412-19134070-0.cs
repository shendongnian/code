    string PathConn = (MYSQL Connection String goes here)
    OleDbConnection conn = new OleDbConnection(PathConn);
    conn.Open();
    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + loadTextBox.Text + "$]", conn);
    newTable = new DataTable();             
    
    myDataAdapter.Fill(newTable); 
    Now use the Load() Method on the new table:
    newTable.Load(table.CreateDataReader(), <Specify LoadOption here>)
    
