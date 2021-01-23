      try
                    {
                        SqlCommand ClearTableCommand = new SQLiteCommand("delete from " + CurrentTableName + ";", myconnection);
                        ClearTableCommand.ExecuteNonQuery();
                        DataTable myDT;
                        DataView myview;
                        myview = (DataView)dataGrid1.ItemsSource;
                        myDT = myview.ToTable(CurrentTableName);
    
                    
    
                    using (SqlDataAdapter Adapter1 = new SqlDataAdapter("select * from " + CurrentTableName + "", myconnection))
                    {
    
                        Adapter1.UpdateCommand = new SQLiteCommandBuilder(Adapter1).GetUpdateCommand(true);
                        Adapter1.AcceptChangesDuringFill = false;
                        Adapter1.AcceptChangesDuringUpdate = true;
                        Adapter1.Update(myDT);
    
                    }
    
                }
                catch (Exception ex)
                {
    
                    System.windows.MessageBox.Show(ex.Message);
                }
