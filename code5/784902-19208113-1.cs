    public static readonly DependencyProperty RadioButtonVisibilityProperty= 
     DependencyProperty.Register( "RadioButtonVisibility", typeof(Visibility),
     typeof(MyUserControl));
 
    public Visibility RadioButtonVisibility 
    {
        get { return (Visibility)GetValue(RadioButtonVisibilityProperty); }
        set { SetValue(RadioButtonVisibilityProperty, value); }
    }
