    public YourDataType SelectedItem
    {
        get { return selectedItem; }
        set
        {
            if (selectedItem != value)
            {
                if (selectedItem.HasChanges)
                {
                    if (WindowManager.UserAcceptsLoss()) 
                    {
                        selectedItem = value;
                        NotifyPropertyChanged("SelectedItem");
                    }
                    else ResetSelectedItem(selectedItem);
                }
                else 
                {
                    selectedItem = value;
                    NotifyPropertyChanged("SelectedItem");
                }
            }
        }
    }
