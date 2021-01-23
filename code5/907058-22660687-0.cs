      public class MyClass : INotifyPropertyChanged
        {
            private ObservableCollection<double> _myCollection;
    
            public ObservableCollection<double> MyCollection
            {
                get { return _myCollection; }
                set
                { 
                    _myCollection = value;
                    RaisedOnPropertyChanged("MyCollection");
                }
            }
            
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void RaisedOnPropertyChanged(string _PropertyName)
            {
                if (PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
                }
            }
        }
