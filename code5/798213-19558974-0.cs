        private static void OnChartEntriesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ObservableCollection<ChartView>)e.OldValue).CollectionChanged -= new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ChartView_CollectionChanged);   
            ((ObservableCollection<ChartView>)e.NewValue).CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ChartView_CollectionChanged);   
        }
        static void ChartView_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            
        }
