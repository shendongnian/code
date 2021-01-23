    private void loadInThread()
    {
        //getsDataFromSQL() is the method that takes over 2 minutes to do
        //it returns a String Array if that is helpful
        comboEdit1.Dispatcher.BeginInvoke((Action)(() =>
        {
            comboEdit1.Properties.Items.AddRange(getsDataFromSQL());   
        }));
        startup.Abort();
    }
