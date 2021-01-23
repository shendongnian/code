    private Visibility gridColVisibility;
    public Visibility GridColVisibility
    {
        get { return gridColVisibility; }
        set { gridColVisibility = value; RaisePropertyChanged(() => GridColVisibility); }
    }
