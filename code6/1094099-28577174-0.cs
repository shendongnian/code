    class IndexToSliderValueConverter : DependencyObject, IValueConverter
    {
        public Slider Slider
        {
            get { return (Slider)GetValue(SliderProperty); }
            set { SetValue(SliderProperty, value); }
        }
        public static readonly DependencyProperty SliderProperty = DependencyProperty.Register(
            "Slider", typeof(Slider), typeof(IndexToSliderValueConverter));
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (Slider != null && Slider.Ticks != null && Slider.Ticks.Count > 0 && value is int)
            {
                int intValue = (int)value;
                if (intValue >= 0 && intValue < Slider.Ticks.Count)
                {
                    return Slider.Ticks[(int)value];
                }
                throw new ArgumentOutOfRangeException("value must be valid tick index");
            }
            return Binding.DoNothing;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (Slider != null && Slider.Ticks != null && Slider.Ticks.Count > 0 && value is double)
            {
                double doubleValue = (double)value,
                    minDifference = double.MaxValue;
                int index = -1;
                for (int i = 0; i < Slider.Ticks.Count; i++)
                {
                    double difference = Math.Abs(doubleValue - Slider.Ticks[i]);
                    if (difference < minDifference)
                    {
                        index = i;
                        minDifference = difference;
                    }
                }
                return index;
            }
            return Binding.DoNothing;
        }
    }
