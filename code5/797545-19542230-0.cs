        public static readonly DependencyProperty ChartEntriesProperty =
            DependencyProperty.Register("ChartEntries",
                                                typeof(ObservableCollection<ChartEntry>),
                                                typeof(ChartView),
                                                new FrameworkPropertyMetadata(OnChartEntriesChanged));
        private static void OnChartEntriesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
