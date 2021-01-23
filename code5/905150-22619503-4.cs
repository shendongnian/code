    private MyObject myBackground;
    public MyObject MyBackground
    {
        get
        {
            return myBackground;
        }
        set
        {
            myBackground = value;
            NotifyPropertyChanged("MyBackground");
        }
    }
