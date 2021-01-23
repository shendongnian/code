         using (TransactionScope tran = new TransactionScope())
         {
                        connection.Open();
                        System.Diagnostics.Debug.WriteLine("Connection Reuslt Code: " + connection.ResultCode());
                        System.Diagnostics.Debug.WriteLine("Connection State: " +                 connection.State.ToString());
    
                        //Get the tables.
                        DataTable tables = connection.GetSchema("Tables");
                        //Prepare the query to retreive all the add ons.
                        string query = "SELECT name as 'Extension_Name', id as 'extID', updateDate as 'Date' FROM addon";
                        command.CommandText = query;
                        command.ExecuteNonQuery();
    
                        //Retreive the dataset using the command.
                        SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "addon");
    
                        for (int i = 0; i < ds.Tables["addon"].Rows.Count; i++)
                        {
                            //Get the date from the query.
                            long entryDateTicks = (long)ds.Tables["addon"].Rows[i].ItemArray[2];
                            //Add the ticks to the unix date. Devide by 1000 to convert ms to seconds.
                            DateTime unixTime = new DateTime(1970, 1, 1);
                            DateTime entryDate = unixTime.AddSeconds(entryDateTicks / 1000);
    
                            //Add the data to a list/
                            addonList.Add(new FirefoxAddonEntry(
                                ds.Tables["addon"].Rows[i].ItemArray[0].ToString()
                                , ds.Tables["addon"].Rows[i].ItemArray[1].ToString()
                                , entryDate
                                ));
                        }
    
             tran.Complete();
         }
