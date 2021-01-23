    string m_source = "test.xlsx";    
    string m_connString = @"Provider = Microsoft.ACE.OLEDB.12.0; 
                            Data Source = " + m_source + @"; 
                            Extended properties = 'Excel 12.0; 
                            HDR= NO; 
                            IMEX = 1;';";
    using (OleDbConnection conn = new OleDbConnection(m_connString)) 
    {
         conn.Open();         
         string squery = "SELECT f1, f2, f3 FROM [Sheet1$]"; 
         OleDbCommand comm = new OleDbCommand(squery, conn);
         OleDbDataAdapter adapter = new OleDbDataAdapter(comm);                
         DataSet ds = new DataSet();
         adapter.Fill(ds);        
    }
