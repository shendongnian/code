    using Excel = Microsoft.Office.Interop.Excel; 
-
          try
                {
                    System.Data.OleDb.OleDbConnection MyConnection ;
                    System.Data.DataSet DtSet ;
                    System.Data.OleDb.OleDbDataAdapter MyCommand ;
                    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='c:\\mydoc.xls';Extended Properties=Excel 8.0;");
                    //MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='c:\\mydoc.xls';Extended Properties=Excel 12.0;"); 
                    MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                    MyCommand.TableMappings.Add("Table", "TestTable");
                    DtSet = new System.Data.DataSet();
                    MyCommand.Fill(DtSet);
                    dataGridView1.DataSource = DtSet.Tables[0];
                    MyConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show (ex.ToString());
                }
