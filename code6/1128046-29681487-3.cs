    public double RValue
        {
            get { return (double)GetValue(RValueProperty); }
            set { SetValue(RValueProperty, value); }
        }
        public static readonly DependencyProperty RValueProperty =
            DependencyProperty.Register("RValue", typeof(double), typeof(MySlider), new PropertyMetadata(0, ValueChanged));
        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var currentColor = (d as MySlider).Color;
            var newcolor = new Color() { R = (byte)e.NewValue, B = currentColor.B, G = currentColor.G };
            (d as MySlider).Color  = newcolor;
        }
