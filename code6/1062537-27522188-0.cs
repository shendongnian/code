    private void Form1_Load(object sender, EventArgs e)
            {
                DataTable sourceTable = new DataTable();
                sourceTable.Columns.Add("Col1");
    
                for (int i = 0; i < 30; i++)
                    sourceTable.Rows.Add();
    
                var ui = TaskScheduler.FromCurrentSynchronizationContext();
    
                Task.Factory.StartNew(() =>
                {
                    for (int i = 1; i <= sourceTable.Rows.Count - 1; i++)
                    {
    
                        var task = Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(1000);
                            lblProgress.Text = "Hello World" + i;
    
                        }, CancellationToken.None, TaskCreationOptions.None, ui);
    
                        task.Wait();
    
                    }
                });
    
            }
