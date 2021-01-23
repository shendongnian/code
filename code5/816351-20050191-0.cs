    public static readonly DependencyProperty TabNameProperty = DependencyProperty.
        Register("TabName", typeof(string), typeof(TaxCodeMappingFooter));
    public string TabName
    {
        get { return (string)GetTabName(TabNameProperty); }
        set { SetTabName(TabNameProperty, value); }
    }
