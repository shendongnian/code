    public string ImagePath
    {
        get { return (string) GetValue(ImagePathProperty); }
        set { SetValue(ImagePathProperty, value); }
    }
    public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(MainPage), new PropertyMetadata(""));
