    public Stop SelectedStop
    {
        get { return GetValue<Stop>(SelectedStopProperty); }
        set { SetValue(SelectedStopProperty, value); }
    }
    public static readonly PropertyData SelectedStopProperty = RegisterProperty("SelectedStop", typeof(Stop));   
