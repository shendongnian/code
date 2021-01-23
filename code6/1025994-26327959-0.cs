        public class BindingWrapper {
        public static object GetSource(DependencyObject obj) { return (object)obj.GetValue(SourceProperty); }
        public static void SetSource(DependencyObject obj, object value) { obj.SetValue(SourceProperty, value); }
        public static object GetTarget(DependencyObject obj) { return (object)obj.GetValue(TargetProperty); }
        public static void SetTarget(DependencyObject obj, object value) { obj.SetValue(TargetProperty, value); }
        public static readonly DependencyProperty TargetProperty = DependencyProperty.RegisterAttached("Target", typeof(object), typeof(BindingWrapper), new PropertyMetadata(null));
        public static readonly DependencyProperty SourceProperty = DependencyProperty.RegisterAttached("Source", typeof(object), typeof(BindingWrapper), new PropertyMetadata(null, OnSourceChanged));
        static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            SetTarget(d, e.NewValue);
        }
    }
