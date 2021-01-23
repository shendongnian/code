    public partial class SomeView : UserControl
    {
        ...
        public static DependencyProperty ButtonVisiblilityProperty = DependencyProperty.Register("ButtonVisiblility", typeof(Visibility), typeof(SomeView));
        public Visibility ButtonVisiblility
        {
            get { return (Visibility)GetValue(ButtonVisiblilityProperty); }
            set { SetValue(ButtonVisiblilityProperty, value); }
        }
    }
