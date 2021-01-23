    private static TextBox auxDataTextBox = new TextBox();
    public static void goRead()
    {            
        auxDataTextBox.TextChanged += new EventHandler(auxDataIncoming);
        Task.Factory.StartNew(() => { 
            return plcData(); 
        }).ContinueWith(task => {
            auxDataTextBox.Text = task.Result;
        }, null, TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
    }
    private static void auxDataIncoming(object sender, EventArgs e)
    {      
        // Do something
    }
