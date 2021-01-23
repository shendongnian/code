    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(MyButton), new PropertyMetadata(new PropertyChangedCallback(TextPropertyChanged)));
    public static FrameworkPropertyMetadata propertyMetadata =
        new FrameworkPropertyMetadata(TextPropertyChanged);
    private static void TextPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var btn = d as MyButton;
        btn.aTextBlock.Text = e.NewValue.ToString();
    }
