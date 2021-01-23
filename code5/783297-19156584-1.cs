    public Image ShowNextToWatchImage
    {
        get
        {
            return _showNextToWatchImage;
        }
        set
        {
            _showNextToWatchImage = value;
            UpdateNextImage();
            NotifyOfPropertyChange(() => ShowNextToWatchImage);
        }
    }
