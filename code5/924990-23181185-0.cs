    private string _parameter;
    public string Parameter
    {
        get { return _parameter;}
        set
        {
            _parameter = value;
        }
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {   
        _parameter = NavigationContext.QueryString["parameter"];   
    }
