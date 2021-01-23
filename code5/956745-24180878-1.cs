    public ObservableCollection<viewArticle> ModelviewArticleObservableList
    {
        get { return _ModelviewArticleObservableList; }
        set
        {
            if (_ModelviewArticleObservableList != null)
            {
                _ModelviewArticleObservableList.CollectionChanged -= OnCollectionChanged;
            }
            _ModelviewArticleObservableList = value;
            if (_ModelviewArticleObservableList != null)
            {
                _ModelviewArticleObservableList.CollectionChanged += OnCollectionChanged;
            }
            OnPropertyChanged("ModelviewArticleObservableList");
            OnPropertyChanged("ArticleCount");
        }
    }
