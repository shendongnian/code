    public class ExCheckBox : CheckBox
    {
        public static readonly DependencyProperty CheckMarkColorProperty =
            DependencyProperty.Register("CheckMarkColor", typeof(Brush), typeof(ExCheckBox), new UIPropertyMetadata(Brushes.Black));
    
        public Brush CheckMarkColor
        {
            get
            {
                return (Brush)GetValue(CheckMarkColorProperty);
            }
            set
            {
                SetValue(CheckMarkColorProperty, value);
            }
        }
    }
