    public class MyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _retrievedItems;
        public ObservableCollection<string> RetrievedItems
        {
            get
            {
                return _retrievedItems;
            }
            set
            {
                _retrievedItems = value;
                OnPropertychanged("RetrievedItems");
            }
        }
        public MyViewModel()
        {
            // Do whatever you normally do to initialize the view model
        }
        public void Search(string searchParamThatWasInConstructor)
        {
            // do something to get results (deserialization)
            // var results = new JavascriptSerializer( ).Deserialize<List<string>>( searchParamThatWasInConstructor );
            // That's just a fake example
            RetrievedItems = new ObservableCollection<string>(results);
        }
    }
