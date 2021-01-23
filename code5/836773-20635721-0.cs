    public bool ShowNumericControl
    {
        get { return (bool)GetValue(ShowNumericControlProperty); }
        set { SetValue(ShowNumericControlProperty, value); }
    }
    
    public static readonly DependencyProperty ShowNumericControlProperty = 
        DependencyProperty.Register("ShowNumericControl", typeof(bool), 
        typeof(LinkTargetControl), null);
