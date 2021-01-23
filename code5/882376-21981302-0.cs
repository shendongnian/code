    class BinaryImageConverter : IValueConverter
    {
        object IValueConverter.Convert( object value, 
            Type targetType, 
            object parameter, 
            System.Globalization.CultureInfo culture )
        {
            if(value != null && value is byte[])
            {
                byte[] bytes = value as byte[];
    
                MemoryStream stream = new MemoryStream( bytes );
    
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
    
                return image;
            }
    
            return null;
        }
    
        object IValueConverter.ConvertBack( object value, 
            Type targetType, 
            object parameter, 
            System.Globalization.CultureInfo culture )
        {
            throw new Exception( "The method or operation is not implemented." );
        }
    }
    <Image Source="{Binding Path=Image, Converter={StaticResource imgConverter}}" />
.
