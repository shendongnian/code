    public class PathToBitmapConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strFilePath = (string)value;
            if (!String.IsNullOrEmpty(strFilePath))
            {
                Uri refFileUri = new Uri(strFilePath, UriKind.RelativeOrAbsolute);
                if (File.Exists(strFilePath))
                {
                    BitmapImage bitmapImage = null;
                    try
                    {
                        using(FileStream imgFileStream = new FileStream(strFilePath, FileMode.Open, FileAccess.Read))
                        {
                            bitmapImage = new BitmapImage();
                            bitmapImage.BeginInit();
                            bitmapImage.StreamSource = imgFileStream;
                            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                            bitmapImage.EndInit();
                            bitmapImage.Freeze();
                            imgFileStream.Close();
                        }
                    }
                    catch
                    {
                    }
                    return bitmapImage;
                }
            }
            return null;
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
