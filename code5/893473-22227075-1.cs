    public string EditName
    {
        get { return (string)GetValue(EditNameTextProperty); }
        set { SetValue(EditNameTextProperty, value); }
    }
     public static readonly DependencyProperty EditNameTextProperty =
            DependencyProperty.Register("EditName",
                typeof(string),
                typeof(YourClassNameHereForThisControl),
                new FrameworkPropertyMetadata(""));
