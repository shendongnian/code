     public class ImageSelector : IValueConverter
     {
         public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
         {
             if( value == null )
                 return null;
    
             string basePath = System.IO.Path.Combine( Directory.GetCurrentDirectory(), @"Resources\Devices" );
             string imageName = String.Format( "{0}.png", value.ToString() );
             string imageLocation = System.IO.Path.Combine( basePath, imageName );
    
             if( !File.Exists( imageLocation ) )
                imageLocation = System.IO.Path.Combine( basePath, "ImageUnavailable.png" );
    
             return new BitmapImage( new Uri( imageLocation ) );
         }
    
         public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
         {
             throw new NotImplementedException();
         }
    }
