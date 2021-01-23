    static YourControl()
    {
        Control.BackgroundProperty.OverrideMetadata(typeof(YourControl), 
            new PropertyMetadata(Brushes.White, OnBackgroundChanged));
    }
 
    private static void OnBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        // The Background property value changed
    }
