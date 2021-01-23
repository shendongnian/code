    void my()
                {
                    string filelink = "C:\\test.xlsx";
    
                    sql = "UPDATE[sheet1$A1:A1] SET F1 = '" + textBox1.Text.ToString() + "'";
                    ExecuteMyCommand(filelink,sql);
    
                    sql = "UPDATE[sheet1$B1:B1] SET F1 = '" + textBox2.Text.ToString() + "'";
                    ExecuteMyCommand(filelink,sql);
    
                    sql = "UPDATE[sheet1$B2:B2] SET F1 = '" + textBox3.Text.ToString() + "'";
                    ExecuteMyCommand(filelink,sql);
                   
                }
        
                private void ExecuteMyCommand(String filelink,String sql)
                {
         using (System.Data.OleDb.OleDbConnection MyConnection =
                            new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filelink +";Extended Properties=\"Excel 12.0 Xml;HDR=NO\""))
                    {
                         System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                         MyConnection.Open();
                         myCommand.Connection = MyConnection;
                         myCommand.CommandText = sql;
                         myCommand.ExecuteNonQuery();
                    }
                }
