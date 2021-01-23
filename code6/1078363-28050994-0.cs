    public class ComboBoxToggleButton : ToggleButton
    {
        // Dependency Property
        public static readonly DependencyProperty InnerBorderBrushProperty =
         DependencyProperty.Register("InnerBorderBrush", typeof(Brush),
             typeof(ComboBoxToggleButton), new FrameworkPropertyMetadata(Brushes.Transparent));
        // .NET Property wrapper
        public Brush InnerBorderBrush
        {
            get
            {
                return (Brush)GetValue(InnerBorderBrushProperty);
            }
            set
            {
                SetValue(InnerBorderBrushProperty, value);
            }
        }
    }
