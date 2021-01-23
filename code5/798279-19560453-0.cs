    class B
    {
        static B()
        {
            A.SomeValueProperty.OverrideMetadata(
                typeof(B), new PropertyMetadata(SomeValuePropertyChanged);
        }
        private static SomeValuePropertyChanged(
            DependencyObject o, DependencyPropertyChangedArgs e)
        {
            ...
        }
    }
 
