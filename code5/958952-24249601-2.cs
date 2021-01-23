    public static readonly DependencyProperty TestProperty =
        DependencyProperty.RegisterAttached("Test", typeof(string),
                                             typeof(TestAttached),
                                             new PropertyMetadata(TestChanged));
    public static void TestChanged(DependencyObject d,
                                   DependencyPropertyChangedEventArgs e)
    {
        // Place your code here
    }
