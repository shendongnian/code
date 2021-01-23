    public string Image
    {
        get { return _image; }
        set
        {
            if (_image == value)
                return;
            _image = value;
            RaisePropertyChanged("Image");
        }
    }
