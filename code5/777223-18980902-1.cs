    private static TextBox auxDataTextBox = new TextBox();
    public static void goRead()
    {            
        auxDataTextBox.TextChanged += new EventHandler(auxDataIncoming);
        Task.Factory.StartNew(() => { 
            return plcData(); 
        }).ContinueWith((t) => {
            auxDataTextBox.Text = t.Result;
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    private static void auxDataIncoming(object sender, EventArgs e)
    {      
        // Do something
    }
