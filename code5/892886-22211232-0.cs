    item.PropertyChanged += Item_PropertyChanged;
...
    private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if ((sender as YourClass) != null) 
        {
            SaveDataType((YourClass)sender);
        }
    }
