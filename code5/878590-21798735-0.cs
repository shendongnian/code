    private ObservableCollection<string> _imagePathList;
    public ObservableCollection<string> ImagePathList {
        get { return this._imagePathList; }
        set {
            if (this._imagePathList != value)
            {
                this._imagePathList = value;
                // I'm going to assume you have the NotifyPropertyChanged
                // method defined on the view-model
                this.NotifyPropertyChanged();
            }
        }
    }
