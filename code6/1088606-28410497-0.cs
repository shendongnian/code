    [ContentProperty("Control")]
    public class LabelControl : Control
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", 
            typeof(string), typeof(LabelControl), new PropertyMetadata(default(string)));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty ControlProperty =
            DependencyProperty.Register("Control", typeof(Control), typeof(LabelControl), new PropertyMetadata(default(Control)));
        public Control Control
        {
            get { return (Control)GetValue(ControlProperty); }
            set { SetValue(ControlProperty, value); }
        }
    }
