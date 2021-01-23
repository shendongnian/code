    public void DataObjectPastingEventHandler(object sender, DataObjectPastingEventArgs e) 
    {
        Dispatcher.BeginInvoke((Action)delegate()
        {
            MessageBox.Show("Hello");
        }, null);
    }
