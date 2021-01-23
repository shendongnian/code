    public ImageSource Icon
    {
        get { return (BitmapImage)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(IconPropertyName, typeof(ImageSource), 
        typeof(GameIconControl), new PropertyMetadata(null));
    ...
    Icon = new BitmapImage(new Uri("C:\\Image.jpg"));
    ...
    <Image Source="{Binding Icon}" />
