    public Color color
            {
                get { return (Color)GetValue(colorProperty); }
                set { SetValue(colorProperty, value); }
            }
            public static readonly DependencyProperty colorProperty =
                DependencyProperty.Register("color", typeof(Color), typeof(YourClass), new PropertyMetadata(null,colorChanged));
    
            private static void colorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                YourClass c = d as YourClass;
                if(c!=null)
                {
    
                }
            }
