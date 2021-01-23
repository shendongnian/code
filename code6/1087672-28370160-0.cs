        public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register(
                        "Value",
                        typeof(double),
                        typeof(RangeBase),
                        new FrameworkPropertyMetadata(
                                0.0d,
                                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | 
                                FrameworkPropertyMetadataOptions.Journal,
                                new PropertyChangedCallback(OnValueChanged),
                                new CoerceValueCallback(ConstrainToRange)),
                        new ValidateValueCallback(IsValidDoubleValue));
  
        internal static object ConstrainToRange(DependencyObject d, object value)
        {
            RangeBase ctrl = (RangeBase) d;
            double min = ctrl.Minimum;
            double v = (double) value;
            if (v < min)
            {
                return min;
            }
 
            double max = ctrl.Maximum;
            if (v > max)
            {
                return max;
            }
 
            return value;
        }
