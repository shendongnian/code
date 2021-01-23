    public bool IsCheckedSetting
    {
        set
        {
            if (value == isChecked)
                return;
            isChecked = value;
            RaisePropertyChanged(() => IsChecked);
        }
    }
