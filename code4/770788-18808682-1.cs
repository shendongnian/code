        public partial class MainWindow : Window
        {
            public List<int> Items
            {
                get;
                set;
            }
        }
        [ValueConversion(typeof(int), typeof(Image))]
        public class RatingConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                int rate = (int)value;
                string imagePath = "1star.png";
                if (rate > 10)
                {
                    imagePath = "2star.png";
                }
                return new BitmapImage(new Uri(imagePath, UriKind.Relative));
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
