    double minLeft = double.MaxValue;
    double minTop = double.MaxValue;
    double left = Canvas.GetLeft(item);
    double top = Canvas.GetTop(item);
   
    minLeft = double.IsNaN(left) ? 0 : Math.Min(left, minLeft);
    minTop = double.IsNaN(top) ? 0 : Math.Min(top, minTop);
                      
    double deltaHorizontal = Math.Max(-minLeft, e.HorizontalChange);
    double deltaVertical = Math.Max(-minTop, e.VerticalChange);
