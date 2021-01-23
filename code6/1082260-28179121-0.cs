    public bool IsSelected
    {
        get
        {
            return isSelected;
        }
        set
        {
            if (isSelected != value)
            {
                isSelected = value;
                OnPropertyChanged("IsSelected"); // if you are implementing INotifyPropertyChanged
            }
        }
    }
