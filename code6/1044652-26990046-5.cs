    static ClassA()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ClassA), new FrameworkPropertyMetadata(typeof(ClassA)));
    }
    
    //and in ClassB
    static ClassA()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ClassA), new FrameworkPropertyMetadata(typeof(ClassA)));
    }
