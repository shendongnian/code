    internal class SearchViewModel : INotifyPropertyChanged
        {
            public void RaisePropertyChanged(string propertyname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private string _searchLastName=string.Empty;
    
            public string SearchLastName
            {
                get { return _searchLastName; }
                set
                {
                    _searchLastName = value;
                    RaisePropertyChanged("SearchLastName");
                }
            }
            
        }
