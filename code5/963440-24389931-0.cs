    public void DataObjectPastingEventHandler(object sender, DataObjectPastingEventArgs e) 
    {
        Dispatcher.CurrentDispatcher.Invoke((Action)delegate()
        {
            MessageBox.Show("Hello");
        });
    }
