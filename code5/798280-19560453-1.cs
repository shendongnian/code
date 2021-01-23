    class ClassB
    {
        static ClassB()
        {
            ClassA.SomeValueProperty.OverrideMetadata(
                typeof(ClassB), new PropertyMetadata(SomeValuePropertyChanged);
        }
        private static SomeValuePropertyChanged(
            DependencyObject o, DependencyPropertyChangedArgs e)
        {
            ...
        }
    }
 
