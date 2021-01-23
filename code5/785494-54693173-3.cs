    public partial class MyUserControl : UserControl
    {
        public static readonly DependencyProperty Value1Property;
        public static readonly DependencyProperty Value2Property;
        static MyUserControl()
        {
            Value1Property = DependencyProperty.Register("Value1", typeof(string), typeof(MyUserControl), new FrameworkPropertyMetadata { DefaultValue = null, BindsTwoWayByDefault = true });
            Value2Property = DependencyProperty.Register("Value2", typeof(string), typeof(MyUserControl), new FrameworkPropertyMetadata { DefaultValue = null, BindsTwoWayByDefault = true });
        }
        public MyUserControl()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            { 
                Binding value1Binding = BindingOperations.GetBinding(this, Value1Property);
                if (value1Binding != null) txtBox1.SetBinding(TextBox.TextProperty, value1Binding);
                Binding value2Binding = BindingOperations.GetBinding(this, Value2Property);
                if (value2Binding != null) txtBox2.SetBinding(TextBox.TextProperty, value2Binding);
            };
        }
        public string Value1
        {
            get { return (string)GetValue(Value1Property); }
            set { SetValue(Value1Property, value); }
        }
        public string Value2
        {
            get { return (string)GetValue(Value2Property); }
            set { SetValue(Value2Property, value); }
        }
    }
