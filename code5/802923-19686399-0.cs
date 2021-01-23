    public static readonly DependencyProperty TargetValueProperty = 
    DependencyProperty.Register("TargetValue", typeof (int), typeof (ProgressEx), 
    new FrameworkPropertyMetadata(0, OnTargetValueChanged));
    private static void OnTargetValueChanged(DependencyObject dependencyObject, 
    DependencyPropertyChangedEventArgs e)
    {
        // Do something with the e.NewValue and/or e.OldValue values here
    }
