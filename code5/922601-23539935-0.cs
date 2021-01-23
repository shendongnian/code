             public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
           {
               ImageSource img = null;
               try
               {
                   if (value != null)
                   {
   
   
                       switch(value.ToString())
                       {
                           case "1": value = "Assets/IT_showcase_tile_bg.png";
                               break;
                           case "2": value = "Assets/IT_institute_tile_bg.png";
                               break;
                           
                           default: break;
                       }
   
                       BitmapImage image = new BitmapImage();
                       image.SetSource(Application.GetResourceStream(new Uri(@value.ToString(), UriKind.Relative)).Stream);
                       img = image;
   
      
                   }
               }
               catch (Exception ex)
               {
   
               }
               return img;
   
           }
           public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
           {
               throw new NotImplementedException();
           } 
}
