    using System;
    using System.IO;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;
    
    namespace MyProject
    {
        public class Base64ImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                string base64String = value as string;
                if (base64String == null)
                    return null;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(System.Convert.FromBase64String(base64String));
                bitmapImage.EndInit();
                return bitmapImage;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
