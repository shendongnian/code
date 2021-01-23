    private Item scanningItem;
    public Item ScanningItem
    {
        get
        {
            return scanningItem;
        }
        private set
        {
            if (Equals(scanningItem, value))
            {
                return;
            }
            scanningItem = value;
            RaisePropertyChanged("ScanningItem");
        }
    }
