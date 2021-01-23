    public static DependencyProperty BitByteProperty = 
        DependencyProperty.Register
        (
            ...
            //Listen for changes in the model:
            new PropertyMetadata(OnByteChanged)
        );
