    public class FilterableObservableCollection : ObservableCollection<ListViewItem>
    {
        private bool notArchivedOnlyFilterEnabled;
    
        public IEnumerable<ListViewItem> FilteredItems
        {
            get
            {
                if (notArchivedOnlyFilterEnabled)
                {
                    return this.Where(x => x.IsArchived == false);
    
                }
                else
                {
                    return this;
                }
            }
        }
    
        public bool NotArchivedOnlyFilterEnabled
        {
            get { return notArchivedOnlyFilterEnabled; }
            set
            {
                notArchivedOnlyFilterEnabled = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FilteredItems"));
            }
        }
    }
    
