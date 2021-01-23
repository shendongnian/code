    <YourElement.Margin>
        <MultiBinding Converter="{StaticResource myMarginConverter}">
          <Binding Path="X"/>
          <Binding Path="Y"/>
        </MultiBinding>
    </YourElement.Margin>
. 
 
    public class NameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //Validate parameters...
    
            Thickness margin = new Margin(values[0], values[1], 0d, 0d);
            return margin;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //Validate parameters...
            double x = ((Thickness)value).Left;
            double y = ((Thickness)value).Top;
            return new object[]{x, y};
        }
    }
