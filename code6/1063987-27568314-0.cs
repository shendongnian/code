    private YourDataType selectedItem = new YourDataType();
    public YourDataType SelectedItem
    {
        get { return selectedItem; }
        set 
        {
            selectedItem = value; 
            NotifyPropertyChanged("SelectedItem"); 
            DoSomethingWithSelectedItem(SelectedItem); // <-- Call method here
        }
    }
