    public class ViewModel : INotifyPropertyChanged
    {
        // use ObservableCollection<T> if you want to add remove items after assigning
        private List<string> _collection;
        public List<string> Collection
        {
            get { return _collection; }
            set 
            {
                _collection = value;
                RaiseNotifyPropertyChanged("Collection");
            } 
    }
