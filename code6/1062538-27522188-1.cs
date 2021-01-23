    var ui = TaskScheduler.FromCurrentSynchronizationContext();
    
                Task.Factory.StartNew(() =>
                {
                    for (int i = 1; i <= sourceTable.Rows.Count - 1; i++)
                    {
    
                        var task = Task.Factory.StartNew(() =>
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
    
    
                            //Thread.Sleep(1000);
    
                            lblProgress.Text = "Hello World" + i;
    
                        }, CancellationToken.None, TaskCreationOptions.None, ui);
    
                        task.Wait();
    
                    }
                });
