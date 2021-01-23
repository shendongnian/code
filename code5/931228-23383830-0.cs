    public class ObjectHolder : DependencyObject
    {
        public object HeldObject
        {
            get { return (object)GetValue(HeldObjectProperty); }
            set { SetValue(HeldObjectProperty, value); }
        }
        // Using a DependencyProperty as the backing store for HeldObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeldObjectProperty =
            DependencyProperty.Register("HeldObject", typeof(object), typeof(ObjectHolder), new PropertyMetadata(null));
    }
