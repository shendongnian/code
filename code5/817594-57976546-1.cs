    public partial class Wifi : UserControl
        {
            public Wifi()
            {
                InitializeComponent();
            }
            public int QualityRateValue
            {
                get { return (int)GetValue(QualityRateValueProperty); }
                set { SetValue(QualityRateValueProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for RatingValue.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty QualityRateValueProperty =
                DependencyProperty.Register("QualityRateValue", typeof(int), typeof(Wifi), new UIPropertyMetadata(0));
        }
        public class QualityRateConverter : IValueConverter
        {
            public Brush OnBrush { get; set; }
            public Brush OffBrush { get; set; }
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                int rating = 0;
                int number = 0;
                if (int.TryParse(value.ToString(), out rating) && int.TryParse(parameter.ToString(), out number))
                {
                    if (rating >= number)
                    {
                        return OnBrush;
                    }
                    return OffBrush;
                }
                return Brushes.Transparent;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
