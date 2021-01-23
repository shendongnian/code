    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // you could examine e to check if there is an actual change in the count first
        OnPropertyChanged("ArticleCount");
    }
