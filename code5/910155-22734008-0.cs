    public static DependencyProperty ButtonVisibilityProperty = DependencyProperty.Register("ButtonVisibility", typeof(Visibility), typeof(SomeView));
    public Visibility ButtonVisibility
    {
        get { return (Visibility)GetValue(ButtonVisibilityProperty); }
        set { SetValue(ButtonVisibilityProperty, value); }
    }
