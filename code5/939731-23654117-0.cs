    public class MyViewModel : INotifyPropertyChanged
    {
        private string _title;
        private ObservableCollection<string> _items;
    
        public string LabelText
        { 
            get { return _title; } 
            set 
            { 
                _title = value;
                this.RaisePropertyChanged("Title");
            }
        }
    
        public ObservableCollection<string> ListItems { 
            get { return _items; }
            set 
            { 
                _items = value;   //Not the best way to populate your "items", but this is just for demonstration purposes.
                this.RaisePropertyChanged("ListItems");
            }
        }
    
        //Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
    }
