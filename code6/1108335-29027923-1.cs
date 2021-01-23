    public class ViewModel : INotifyPropertyChanged
    {
        private string _searchTerm;
        public ViewModel()
        {
            Contacts = new ObservableCollection<string>
            {
                "Peter", "Daniel", "Kate", "John", "Anthony", "Laura", "Charles"
            };
            FilteredContacts = new ListCollectionView(Contacts);
            FilteredContacts.Filter = contact => string.IsNullOrWhiteSpace(SearchTerm) || ((string)contact).Contains(SearchTerm);
        }
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                if (value == _searchTerm) return;
                _searchTerm = value;
                OnPropertyChanged("SearchTerm");
                FilteredContacts.Refresh();
            }
        }
        public ObservableCollection<string> Contacts { get; private set; }
        public CollectionView FilteredContacts { get; private set; }
    }
