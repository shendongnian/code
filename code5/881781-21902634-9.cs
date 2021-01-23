    async void Form_Load(object sender, EventArgs e)
    {
        // UI thread
        var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        await Task.Run(async () =>
        {
            // pool thread
            try
            {
                await Task.Factory.StartNew(
                    () => Test(), 
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    taskScheduler);
            }
            catch (Exception ex)
            {
                // handle the error on a pool thread
                Debug.Print(ex.ToString());
            }
        });
    }
