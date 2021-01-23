    public class ToImageSource : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {       
         if (value == null) return null;
         else
         {
            byte[] imageBytes = Convert.FromBase64String(value);
            using (MemoryStream stream = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
              stream.Write(imageBytes, 0, imageBytes.Length);
              BitmapImage bitmap = new BitmapImage();
              bitmap.SetSource(stream);
              return bitmap;
            }         
         }
      }
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {   // implement ConvertBack      }
    }
