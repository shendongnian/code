            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "/swtlist.xlsx;" +
                         @"Extended Properties='Excel 12.0;HDR=Yes;';Persist Security Info=False;";
        
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                try
                {
                    DataTable dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    OleDbCommand cmd = new OleDbCommand("UPDATE  [Feuil1$]  SET d='yes' ", connection);
                   
                      cmd.ExecuteNonQuery();
                    connection.Close();
                  
                }
                catch (Exception ex) { }
            }
