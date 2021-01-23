    public static readonly DependencyProperty MyTextPropertyChanged =
        DependencyProperty.Register
        (
                "MyTextProperty",
                typeof(ClassA), 
                typeof(string),
                new FrameworkPropertyMetadata
                (
                        default(string), 
                        //the next line enables the binding back to source:
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                        MyTextPropertyChanged
                )
        );
    public static void MyTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs)
    {
        //handling changed event
    }
