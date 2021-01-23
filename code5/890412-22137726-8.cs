    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<MyModel> ListItems 
        { 
            get { return _listItems; }
            set
            {
                _listItems = value;
                RaisePropertyChanged("ListItems");
            }
        } 
       
    }
