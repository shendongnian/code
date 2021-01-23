    private string _assetId;
    public string AssetId
    {
        get
        {
            return _assetId;
        }
        set
        {
            _assetId = value;
            OnPropertyChanged();
        }
    }
