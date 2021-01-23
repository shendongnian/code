    public static readonly DependencyProperty DashesProperty =
            DependencyProperty.Register("Dashes", typeof(DoubleCollection), typeof(CustomTextBlock),
            new UIPropertyMetadata(CreateDefaultDashes()));
    
    private static DoubleCollection CreateDefaultDashes()
    {
        var dashes = new DoubleCollection { 4, 4 };
        dashes.Freeze();
        return dashes;
    }
