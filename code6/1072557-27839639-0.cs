    // Your property
    public string InfoMessage{get;set;}
    // Register Dependency Property
    public static readonly DependencyProperty InfoMessageProperty =
    DependencyProperty.Register("InfoMessage", typeof(string), typeof(ItemInfoView),
            new UIPropertyMetadata(true));
