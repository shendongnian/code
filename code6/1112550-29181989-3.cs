    class MyWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<SeriesInfo> RolloverSeriesWithoutFirstData
        {
            /* ... */
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        public MyWindow()
        {
            // Get rolloverModifier
            rolloverModifier.SeriesData.PropertyChanged += SeriesDataPropertyChanged;
        }
        private void SeriesDataPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "SeriesInfo":
                    RaisePropertyChanged("RolloverSeriesWithoutFirstData");
                    break;
            }
        }
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if(handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
