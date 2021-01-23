    public class ViewModel {
        // ...
        public ViewModel(ObservableCollection<ItemViewModel> items)
        {
            _source = new CollectionViewSource()
            {
                Source = items,
                IsLiveFilteringRequested = true,
                LiveFilteringProperties = { "FilterProperty" }
            };
            _source.Filter += (src, args) =>
            {
                args.Accepted = ((ItemViewModel) args.Item).FilterProperty == FilterField;
            };
        }
        // ...
        public ICollectionView View
        {
            get { return _source.View; }
        }
        // ...
    }
