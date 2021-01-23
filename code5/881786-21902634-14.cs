    int Test()
    {
        throw new InvalidOperationException("Surpise from the UI thread!");
    }
    async void Form_Load(object sender, EventArgs e)
    {
        // UI thread
        var uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        await Task.Run(async () =>
        {
            // pool thread
            try
            {
                await Task.Factory.StartNew(
                    () => Test(), 
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    uiTaskScheduler);
            }
            catch (Exception ex)
            {
                // handle the error on a pool thread
                Debug.Print(ex.ToString());
            }
        });
    }
