    string excelconnectionstring = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelfilepath + ";Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text;Jet OLEDB:Max Buffer Size=256;");
    
    using (OleDbConnection oledbconn = new OleDbConnection(excelconnectionstring))
      {
                        using (OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn))
                        {
                            oledbconn.Open();
                            OleDbDataReader dr = oledbcmd.ExecuteReader();
    
    
                            dtBulkUpload.Load(dr);
    }
    }
