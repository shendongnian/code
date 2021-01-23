    private YourDataType selectedItem;
    public YourDataType SelectedItem
    {
        get { return selectedItem; }
        set
        {
            // selectedItem represents the previous TabItem
            // value represents the new TabItem
            selectedItem = value;
        }
    }
