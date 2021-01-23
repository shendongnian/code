    public Document Document
    {
        get { return this._document; }
        set
        {
            if (this._document == value)
                return;
            this._document = value;
            RaisePropertyChanged("Document");
        }
    }
    public async Task<Document> GetDocument
    {
        // ...
    }
    private async Task LoadData()
    {
        Document = GetDocument();
    }
    public void Initialize() 
    {
        LoadData();
    }
