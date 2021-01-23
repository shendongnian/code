    class ViewModel
        {
            private List<string> _collection = new List<string>(); 
            private string _searchTerm;
    
            public ListCollectionView ValuesView { get; set; }
    
            public string SearchTerm
            {
                get
                {
                    return _searchTerm;
                }
                set
                {
                    _searchTerm = value;
                    ValuesView.Refresh();
                }
            }
    
            public ViewModel()
            {
                _collection.AddRange(Enumerable.Range(0, 100000).Select(p => Guid.NewGuid().ToString()));
    
                ValuesView = new ListCollectionView(_collection);
                ValuesView.Filter = o =>
                    {
                        var listValue = (string)o;
                        return string.IsNullOrEmpty(_searchTerm) || listValue.Contains(_searchTerm);
                    };
            }
        }
