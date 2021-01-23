    public static readonly DependencyProperty RadioButtonVisibilityProperty= 
     DependencyProperty.Register( "RadioButtonVisibility", typeof(Visibility),
     typeof(RadioButton));
 
    public Visibility RadioButtonVisibility 
    {
        get { return (Visibility)GetValue(RadioButtonVisibilityProperty); }
        set { SetValue(RadioButtonVisibilityProperty, value); }
    }
