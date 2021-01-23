    private static void OnChartEntriesChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var chartView = (ChartView)obj;
        var oldCollection = e.OldValue as INotifyCollectionChanged;
        var newCollection = e.NewValue as INotifyCollectionChanged;
        if (oldCollection != null)
        {
            oldCollection.CollectionChanged -= chartView.OnChartEntriesCollectionChanged;
        }
        if (newCollection != null)
        {
            newCollection.CollectionChanged += chartView.OnChartEntriesCollectionChanged;
        }
    }
    private void OnChartEntriesCollectionChanged(
        object sender, NotifyCollectionChangedEventArgs e)
    {
        ...
    }
