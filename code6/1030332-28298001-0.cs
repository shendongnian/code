    private MyModel albumSelectedItem;
    public MyModel AlbumSelectedItem
    {
        get
        {
            return albumSelectedItem;
        }
        set
        {
            if (value != null && albumSelectedItem != value)
            {
                albumSelectedItem = value;
                RaisePropertyChanged(() => AlbumSelectedItem);
            }
        }
    }
    public void DeleteItem(MyModel p)
    {
        //P is always null here...
        var pp = AlbumSelectedItem;
    }
