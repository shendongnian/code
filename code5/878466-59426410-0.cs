    private Image _imageOpenClose;
    public Image ImageOpenClose
    {
        get
        {
            return _imageOpenClose;
        }
        set
        {
            _imageOpenClose = value;
            OnPropertyChanged();
        }
    }
