    // somewhere in code, where `MyModel` being initialized:
    MyModel.Series.CollectionChanged += (sender, args) => RaisePropertyChanged("IsAnythingSelected");
    MyModel.Series.ItemPropertyChanged += (sender, args) => RaisePropertyChanged("IsAnythingSelected");
    
        public bool IsAnythingSelected
        {
            get
            {
                return MyModel.Series.Any(p => p.IsSelected && p.GetType() == typeof(LineSeries));
            }
        }
