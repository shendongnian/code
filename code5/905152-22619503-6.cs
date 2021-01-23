    private Answer myBackground;
    public Answer MyBackground
    {
        get
        {
            return myBackground;
        }
        set
        {
            myBackground = value;
            OnPropertyChanged("MyBackground");
        }
    }
