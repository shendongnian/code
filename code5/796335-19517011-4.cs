    private GroupItem _item = new GroupItem();
    public GroupItem Item
    {
        get { return _item; }
        set
        {
            if (value != _item)
            {
                _item = value;
                NotifyPropertyChanged("Item");
            }
        }
    }
