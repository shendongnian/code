    private bool canEdit = false;
    public bool CanEdit
    {
        get { return canEdit; }
        set { canEdit = value; NotifyPropertyChanged("CanEdit"); }
    }
