    private ColorViewModel appColor;
    public ColorViewModel AppColor
    {
        get
        {
            return appColor;
        }
        set
        {
            if (value != appColor)
            {
                appColor= value;
                NotifyPropertyChanged("AppColor");
            }
        }
    }
