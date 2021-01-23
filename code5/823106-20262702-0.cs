    private static ObservableCollection<string> steelThickness = new 
        ObservableCollection<string> { "0.3750", "0.4375", "0.5000", "0.6250", "0.7500", 
        "0.8650", "1.0000" };
    public ObservableCollection<string> ComboBoxItemsSource
    {
        get { return new ObservableCollection<string>(
            steelThickness.Where(item => item.MeetsCertainCriteria(item))); }
    }
    private bool MeetsCertainCriteria(string item)
    {
        // return true or false for each item to adjust the members in the collection
        // based on whatever your condition is
        if ( ... ) return true;
        return false;
    }
