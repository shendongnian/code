    public static readonly DependencyProperty DependencyPropertyName= DependencyProperty.Register(
        "DepName", 
        typeof(EnumName), 
        typeof(MyWindow1), 
        new FrameworkPropertyMetadata(
            EnumName.SomeValue, // this is the defalt value
            FrameworkPropertyMetadataOptions.AffectsRender, 
            Target));
