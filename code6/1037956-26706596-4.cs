    public class ColorsToLinearGradientBrushConverter : IValueConverter {
       public object Convert(object value, Type targetType, object parameter,
                                                            CultureInfo culture){
          var colors = (List<Color>) value;
          var brush = new LinearGradientBrush(){ StartPoint = new Point(),
                                                 EndPoint = new Point(0,1)};
          var w = 1d / colors.Count;
          for(var i = 0; i < colors.Count - 1; i++){
             var offset = w * (i+1);
             var stop1 = new GradientStop(colors[i], offset);
             var stop2 = new GradientStop(colors[i+1], offset);
             brush.GradientStops.Add(stop1);
             brush.GradientStops.Add(stop2);
          }
          return brush;
       }
       //this way back is not needed (bind OneWay)
       public object ConvertBack(object value Type targetType, object parameter,
                                                               CultureInfo culture){
          throw new NotImplementedException();
       }
    }
