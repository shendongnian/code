    public class DebugConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         BitmapImage temp = new BitmapImage();
         using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
         using (IsolatedStorageFileStream file = ISF.OpenFile((string)value, FileMode.Open, FileAccess.Read))
            temp.SetSource(file);
         return temp;
      }
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
          throw new NotImplementedException();
      } 
    }
