    public static readonly DependencyProperty ImageUriProperty =
        DependencyProperty.Register("ImageUri", typeof(string), typeof(MainWindow));
    
    public string ImageUri
    {
        get { return (string)GetValue(ImageUriProperty); }
        set { SetValue(ImageUriProperty, value); }
    }
    <Image Source="{Binding ImageUri}"/>
