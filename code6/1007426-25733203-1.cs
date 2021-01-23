      public class MyClas : TargetedTriggerAction<Button>
    {
        public static readonly DependencyProperty MyStyleProperty = DependencyProperty.Register("MyStyle", typeof(Style), typeof(MyClas), new PropertyMetadata());
        public Style MyStyle
        {
            get { return (Style)GetValue(MyStyleProperty); }
            set { SetValue(MyStyleProperty, value); }
        }
        protected override void Invoke(object parameter)
        {
            ((Button)Target).Style = MyStyle;
        }
    }
