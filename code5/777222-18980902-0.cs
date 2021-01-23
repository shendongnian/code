    private static TextBox auxDataTextBox = new TextBox();
    public static void goRead()
    {            
        auxDataTextBox.TextChanged += new EventHandler(auxDataIncoming);
        Task.Factory.StartNew(() => {
            var data = plcdata();
            auxDataTextBox.Invoke(delegate { auxDataTextBox.Text = data; });
        })
    }
    private static void auxDataIncoming(object sender, EventArgs e)
    {      
        // Do something
    }
