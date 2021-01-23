    public event EventHandler DataLoadedEvent;
    void dealsOfDay_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        if (e.Error == null && e.Result != null)
        {
            var deals=//something making  a collection.
            Items = new ObservableCollection<ItemViewModel>(deals);
            NotifyPropertyChanged("Items");
            if ( DataLoadedEvent != null)
            {
                DataLoadedEvent(this, new EventHandler());
            }
        }
        else
        {
            MessageBox.Show("Error");
        }
    }
