    public partial class ButtonWithIcon : Button
    {
        public ButtonWithIcon()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty IconContentProperty =
            DependencyProperty.Register("IconContent", typeof (Icon), typeof (ButtonWithIcon), new PropertyMetadata(default(Icon)));
        public Icon IconContent
        {
            get { return (Icon) GetValue(IconContentProperty); }
            set { SetValue(IconContentProperty, value); }
        }
    }
