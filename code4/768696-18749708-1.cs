    public class MyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _retrievedItems;
        private string _selectedItem;
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
        public string SelectedItem
        {
            // same as other property, but with _selectedItem
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
            SelectedItem = RetrievedItems.Count > 0 ? RetrievedItems[0] : string.Empty;
        }
    }
