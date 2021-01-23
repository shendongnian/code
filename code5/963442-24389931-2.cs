    public void DataObjectPastingEventHandler(object sender, DataObjectPastingEventArgs e) 
    {
        Dispatcher.CurrentDispatcher.BeginInvoke((Action)delegate()
        {
            MessageBox.Show("Hello");
        }, null);
    }
