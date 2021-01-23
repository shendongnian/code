    var ui = TaskScheduler.FromCurrentSynchronizationContext();
    
                Task.Factory.StartNew(() =>
                {
                    for (int i = 1; i <= sourceTable.Rows.Count - 1; i++)
                    {
                            string checkout;
                            checkout = sourceTable.Rows[i].Field<string>(0);
    
                            dest = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["local"].ConnectionString);
                            dest.Open();
                            destcmd = new SqlCommand(checkout, dest);
                            destcmd.ExecuteNonQuery();
                            dest.Close();
    
                            prcmail();
                            prcmessagecheck();
                        var task = Task.Factory.StartNew(() =>
                        {      
                             //Thread.Sleep(1000);
    
                            lblProgress.Text = "Hello World" + i;
    
                        }, CancellationToken.None, TaskCreationOptions.None, ui);
    
                        task.Wait();
    
                    }
                });
