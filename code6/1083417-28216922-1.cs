    public bool AreAllCheckBoxesChecked
    {
        get { return areAllCheckBoxesChecked; }
        set 
        {
            areAllCheckBoxesChecked = value;
            foreach (YourDataType item in YourCollection)
            {
                item.IsSelected = value;
            }
            NotifyPropertyChanged("AreAllCheckBoxesChecked"); 
        }
    }
