      public class ButtonImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                
    
                if((bool) value)
    return  CreateImage("pack://application:,,,/ButtonEnabled.ico"); // url should be correct
    else  return  CreateImage("pack://application:,,,/ButtonDisable.ico");
    
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
    
            /// <summary>
            /// Method to create an image to bind to icons in treeview
            /// </summary>
            /// <param name="uriToImage">uri to image in folder.</param>
            /// <returns>a bitmap image to bind to image source in tree view</returns>
            private BitmapImage CreateImage(string uriToImage)
            {
                if (!string.IsNullOrEmpty(uriToImage))
                {
                    BitmapImage genericBitmap = new BitmapImage();
                    genericBitmap.BeginInit();
                    genericBitmap.UriSource = new Uri(uriToImage);
                    genericBitmap.EndInit();
                    return genericBitmap;
                }
    
                return null;
    
            }
        }
