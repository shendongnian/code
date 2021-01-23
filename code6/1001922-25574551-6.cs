    public class Base64ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string base64String = value as string;
            if (base64String == null)
                return null;
            return ImageHelper.Base64StringToBitmapImage(base64String);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public static class ImageHelper
    {
        public static BitmapImage Base64StringToBitmapImage(string base64String)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(Convert.FromBase64String(base64String));
            bitmapImage.EndInit();
            return bitmapImage;
        }
        public static string FileToBase64String(string filename)
        {
            using (var stream = File.Open(filename, FileMode.Open))
            using (var reader = new BinaryReader(stream))
            {
                byte[] allData = reader.ReadBytes((int)reader.BaseStream.Length);
                return Convert.ToBase64String(allData);
            }
        }
    }
