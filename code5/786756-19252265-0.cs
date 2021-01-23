    private string selectedItem = string.Empty;
    ...
    public string SelectedItem
    {
        get { return selectedItem; }
        set
        {
            selectedItem = value;
            NotifyPropertyChange("SelectedItem"); // << Implement INotifyPropertyChanged
            UpdateGrid();
        }
    }
