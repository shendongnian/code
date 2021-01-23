    private uint _ID;
    public uint ID
    {
        get { return _ID; }
        set
        {
            if (_ID == value) return;
            _ID = value;
            NotifyOfPropertyChange("ID");
            // Do something with your second ComboBox.
            // You could create another ObservableCollection and bind that to your second                   ComboBox and add some items representing the Account IDs
        }
    }
