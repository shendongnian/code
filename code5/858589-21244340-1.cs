    public ImageSource Icon
    {
        get { return (ImageSource)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(IconPropertyName, typeof(ImageSource), 
        typeof(GameIconControl), new PropertyMetadata(null));
    ...
    Icon = new BitmapImage(new Uri("C:\\Image.jpg"));
    ...
    <Image Source="{TemplateBinding Icon}" />
