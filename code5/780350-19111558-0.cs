    public class Helper : Control
    {
        public bool MyInheritsProp
        {
            get { return (bool)GetValue(MyInheritsPropProperty); }
            set { SetValue(MyInheritsPropProperty, value); }
        }
        public static readonly DependencyProperty MyInheritsPropProperty =
            DependencyProperty.Register("MyInheritsProp", typeof(bool), typeof(Helper), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
    }
    public class MyControl: Helper
    {
        static MyControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyControl), new FrameworkPropertyMetadata(typeof(MyControl)));
            MyInheritsPropProperty.OverrideMetadata(typeof(MyControl), new FrameworkPropertyMetadata(true));
        }
    }
