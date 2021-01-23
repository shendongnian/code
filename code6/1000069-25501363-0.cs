    public static DependencyProperty HeaderTextProperty = DependencyProperty.Register(
        "HeaderText", 
        typeof(string), 
        typeof(DefaultText), 
        new PropertyMetadata(string.Empty, PropertyChangedCallback)
    );
    
    private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
    {
        // this is the method that is called whenever the dependency property's value has changed
    }
