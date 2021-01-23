    private ImageSource _source;
    public ImageSource PImage1
    {
        get
        {
            if (_source == null)
            {
                using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (storage.FileExists("Image.jpg"))
                    {
                        var bitmap = new BitmapImage();
                        bitmap.SetSource(storage.OpenFile("Image.jpg", FileMode.Open));
                        _source = bitmap;
                        return _source;
                    }
                }
                LoadImage();
            }
            return _source;
        }
        set
        {
            _source = value;
            OnPropertyChanged("PImage1");
        }
    }
