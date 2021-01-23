    public static readonly DependencyProperty ChartEntriesProperty = DependencyProperty.
    Register("ChartEntries", typeof(ObservableCollection<ChartEntry>), typeof(ChartView));
    public ObservableCollection<ChartEntry> ChartEntries
    {
        get { return (ObservableCollection<ChartEntry>)GetValue(ChartEntriesProperty); }
        set { SetValue(ChartEntriesProperty, value); }
    }
