    private listViewItem yourSelectedItem;
    public listViewItem YourSelectedItem
    { 
        get { return yourSelectedItem; }
        set
        {
            yourSelectedItem = value;
            NotifyPropertyChanged("YourSelectedItem");
            // The selected item changed so you can do something with the new item here
         }
    }
