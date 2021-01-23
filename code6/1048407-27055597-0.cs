    private ObservableCollection<SearchResult> _ImageResults;
    public ObservableCollection<SearchResult> ImageResults {
        get
        {
            return _ImageResults;
        }
        set {
            _ImageResults = value;
        }
    }
    public SearchResultViewModel() {
       _ImageResults = new ObservableCollection<SearchResult>(); // Just create it once.
       GetPictures("dogs");
    }
    private void OnQueryComplete(IAsyncResult result) {
        _ImageResults.Clear(); // Clear isn't bad, that way you keep your reference to your original collection!
        //_ImageResults = new ObservableCollection<SearchResult>(); // We already have one. ObservableCollection works best if you keep on working with the collection you have.
        var query = (DataServiceQuery<ImageResult>)result.AsyncState;
        var enumerableResults = query.EndExecute(result);
        int i = 0;
        foreach (var item in enumerableResults) {
            SearchResult myResult = new SearchResult();
            myResult.Title = item.Title;
            myResult.ImageUri = new Uri(item.MediaUrl);
            ImageResults.Add(myResult);
            i++;
            if (i >= 14) {
                break;
            }
        }
    }
