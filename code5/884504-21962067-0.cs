    Brush br = Brushes.Green;
    byte a = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).A;
    byte g = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).G;
    byte r = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).R;
    byte b = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).B;
    System.Windows.Forms.ControlPaint.Light(
        System.Drawing.Color.FromArgb((int)a,(int)r,(int)g,(int)b));
