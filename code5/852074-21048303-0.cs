    public class LauncherButton : ButtonBase {
      ...
    
      public static readonly DependencyProperty NormalBorderBrushProperty =
        DependencyProperty.Register("NormalBorderBrush", typeof(Brush), typeof(LauncherButton),
          new UIPropertyMetadata(Brushes.Blue));
    
      public static readonly DependencyProperty MouseOverBorderBrushProperty =
        DependencyProperty.Register("MouseOverBorderBrush", typeof(Brush), typeof(LauncherButton),
          new UIPropertyMetadata(Brushes.Red));
     
      public Brush NormalBorderBrush
      {
        get { return (Brush)GetValue(NormalBorderBrushProperty); }
        set { SetValue(NormalBorderBrushProperty, value); }
      }
    
      public Brush MouseOverBorderBrush
      {
        get { return (Brush)GetValue(MouseOverBorderBrushProperty); }
        set { SetValue(MouseOverBorderBrushProperty, value); }
      }
    }
