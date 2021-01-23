    using System;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
    
    namespace Sample
    {
        /// <summary>
        /// Interaction logic for UserControl2.xaml
        /// </summary>
        public partial class UserControl2 : UserControl
        {
            public UserControl2()
            {
                InitializeComponent();
            }
        }
    
        public class Data
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Color { get; set; }
            public bool isactive { get; set; }
        }
        public class StringToColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return (Color)ColorConverter.ConvertFromString((string)value);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return ((Color)value).ToString();
            }
        }
    }
