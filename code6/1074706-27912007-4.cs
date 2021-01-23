        public Brush LegendColor
        {
            get { return (Brush)GetValue(LegendColorProperty); }
            set { SetValue(LegendColorProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LegendColorProperty =
            DependencyProperty.Register("LegendColor", typeof(Brush), typeof(LegendLabel), new PropertyMetadata(null, HandleBrushChange));
