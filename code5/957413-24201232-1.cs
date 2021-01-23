    public static readonly DependencyProperty MainTabProperty =
        DependencyProperty.Register(
            "MainTab", typeof(Control), typeof(CustomClass));
    public Control MainTab
    {
        get { return (Control)GetValue(MainTabProperty); }
        set { SetValue(MainTabProperty, value); }
    }
