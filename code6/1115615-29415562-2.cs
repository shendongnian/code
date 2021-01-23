      public class TestViewModel : INotifyPropertyChanged
        {
            private bool _displaySumarry;
            public bool DisplaySummaryPopup
            {
                get { return _displaySumarry;  }
                set
                {
                    _displaySumarry = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
