    namespace WpfApplication14
    {
        /// <summary>
        /// Interaction logic for UserControl1.xaml
        /// </summary>
        public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
                DataContext = this;
            }
    
            public int RatingValue
            {
                get { return (int)GetValue(RatingValueProperty); }
                set { SetValue(RatingValueProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for RatingValue.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty RatingValueProperty =
                DependencyProperty.Register("RatingValue", typeof(int), typeof(UserControl1), new UIPropertyMetadata(0));
        }
    
        public class RatingConverter : IValueConverter
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
    }
