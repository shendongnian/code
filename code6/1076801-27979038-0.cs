    public SetIsSelected(bool value)
    {
        if (isSelected == value) {
            return;
        }
        isSelected = value;
        RaisePropertyChanged("IsSelected");
    }
