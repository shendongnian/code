    public bool IsSelected
    { 
        get { return isSelected; }
        set { if (IsRealized) { isSelected = value; NotifyPropertyChanged("IsSelected"); }
    }
