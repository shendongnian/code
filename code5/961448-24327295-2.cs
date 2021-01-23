    string m_source = "testxls.xlsx";
    List<string> m_list = new List<string>();
    string m_connString = @"Provider = Microsoft.ACE.OLEDB.12.0; 
                            Data Source = " + m_source + @"; 
                            Extended properties = 'Excel 12.0; 
                            HDR= NO; 
                            IMEX = 1;';";
    using (OleDbConnection conn = new OleDbConnection(m_connString)) 
    {
         conn.Open();                
         DataSet ds = new DataSet();
         string defaultSheet = "Sheet1$"; 
         OleDbCommand comm = new OleDbCommand("SELECT f1, f2, f3 FROM [" + defaultSheet + "]", conn);
         OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                
         adapter.Fill (ds);
         // Fill a List<string> with the data found
         for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
         {
            m_list.Add(ds.Tables[0].Rows[r][0].ToString());
         }
    }
