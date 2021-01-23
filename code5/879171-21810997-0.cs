    public bool IsActive
    {
        get { return settingsModel.IsActive; }
        set
        {
            if (settingsModel.IsActive != value)
            {
                settingsModel.IsActive
                RaisePropertyChanged("IsActive");
            }
        }
    }
