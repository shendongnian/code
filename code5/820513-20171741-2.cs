    public class SelectedItemToLoadImagesConverter : IValueConverter {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture){
            List<Photos> images = new List<Photos>();
            if (value != null) //If a item has been selected
            {
                foreach (string filename in System.IO.Directory.GetFiles(value.ToString()))
                {
                    try
                    {
                        images.Add( //Add To List
                        new Photos(
                            new BitmapImage(
                                new Uri(filename)),
                                System.IO.Path.GetFileNameWithoutExtension(filename)));
                    }
                    catch { ; } //Skips Any Image That Isn't Image/Cant Be Loaded
                }
            }
            return images;
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture){
        throw new NotImplementedException();
      }
    }
