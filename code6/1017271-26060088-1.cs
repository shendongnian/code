    public partial class MyControl : UserControl
    {
        public static readonly DependencyProperty SomethingProperty = DependencyProperty.Register("Something", typeof(string), typeof(MyControl));
        public string KeyType
        {
            get { return (string)GetValue(SomethingProperty ); }
            set { SetValue(SomethingProperty , value); }
        }
    }
