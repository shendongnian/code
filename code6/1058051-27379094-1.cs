    public DataTable CSVToDataTable(string filename, string separator)
    {
        try
        {
            FileInfo file = new FileInfo(filename);
    
            OleDbConnection con = 
                new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" +
                file.DirectoryName + "\";
                Extended Properties='text;HDR=Yes;FMT=Delimited(" + separator + ")';")
        
            OleDbCommand cmd = new OleDbCommand(string.Format
                                      ("SELECT * FROM [{0}]", file.Name), con);
            
            con.Open();
     
            DataTable tbl = new DataTable();
            
            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
            {
                tbl = new DataTable("MyTable");
                adp.Fill(tbl);        
            }
            return tbl;
         }
         catch(Exception ex)
         {
             throw ex;
         }
         finally()
         {
            con.Close();
         }  
    } 
