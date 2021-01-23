    private ObservableCollection<ImageSource> _Source = new ObservableCollection<ImageSource>();
    public ObservableCollection<ImageSource> Source
    {
        get
        {
            return this._Source;
        }
        set
        {
            if (this._Source != value)
            {
                this._Source = value;
                this.OnPropertyChanged();
            }
        }
    }
