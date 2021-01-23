    //Inside Resources. local=namespace where you have this converter
       <local:ConnectorType2BrushConverter x:Key="ConnectorType2BrushConverter" />
    ....
        <ca:CurvedArrow
        
                            StrokeThickness="2"
                            Points="{Binding Points}"
                            Fill="{Binding Path=ConnectorType, Converter={StaticResource ResourceKey=ConnectorType2BrushConverter}"
                        />
        
        ....
        
            public class ConnectorType2BrushConverter : IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    var connectorType = (ConnectorType)value;
                    if (connectorType == ConnectorType.Arrow)
                    {
                        return new SolidColorBrush(Color.FromRgb(1, 1, 1));
                    }
                    else    .....
                }
        
                public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
            }
