    public FrmSchedulerItemDetails(SchedulerListItem item)
    {
        InitializeComponent();
        this.DetailsControl = new SchedulerListItemDetails(item, this);
    }
    public SchedulerListItemDetails DetailsControl
    {
        get 
        { 
            return this.detailsControl; 
        }
        set 
        {
            this.Controls.Remove(this.detailsControl);
            this.detailsControl = value;
            this.Controls.Add(this.detailsControl);
        }
    }
