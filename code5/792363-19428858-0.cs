    public IEnumerable SelectedItem
    {
    get { return _itemsControl; }
    set
    {
        if (_itemsControl == value)
            return;
        _itemsControl = value;
        // Test
        _mss.ErrorNotification("fd");
    }
