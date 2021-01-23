    public static readonly DependencyProperty SideBarVisibilityProperty = DependencyProperty.Register("SideBarVisibility", typeof(Visibility), typeof(MyTemplatedControl), null);
    public Visibility SideBarVisibility
    {
        get { return (Visibility)GetValue(SideBarVisibilityProperty); }
        set { SetValue(SideBarVisibilityProperty, value); }
    }
