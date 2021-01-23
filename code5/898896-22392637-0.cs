    private IList selectYN;
    public IList SelectYN
    {
        get { return selectYN; }
        set
        {
            if (value != selectYN)
            {
                selectYN = value;
                NotifyOfPropertyChange(() => SelectYN);
            }
         }
    }
...
    <ListView ItemSource="{Binding Items}" SelectedItems="{Binding SelectYN}" ... />
