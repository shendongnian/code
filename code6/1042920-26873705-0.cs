    //the main class used in your XAML code
    public static class DataContextService {
        public static readonly DependencyProperty DataContextFromAncestorProperty = DependencyProperty.RegisterAttached("DataContextFromAncestor", typeof(object), typeof(DataContextService), new UIPropertyMetadata(dataContextPropertyChanged));
        public static object GetDataContextFromAncestor(DependencyObject o)
        {
            return o.GetValue(DataContextFromAncestorProperty);
        }
        public static void SetDataContextFromAncestor(DependencyObject o, object value)
        {
            o.SetValue(DataContextFromAncestorProperty, value);
        }
        private static void dataContextPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            var elem = target as FrameworkElement;
            var type = e.NewValue as Type;
            if (type == null || elem == null) return;            
            if (elem.IsLoaded) SetDataContextFromAncestorOfType(elem, type);
            else {                
                elem.Loaded += loadedHandler;
            }                    
        }
        private static void SetDataContextFromAncestorOfType(FrameworkElement elem, Type ancestorType)
        {
            elem.DataContext = elem.FindAncestorOfType(ancestorType);
        }
        private static void loadedHandler(object sender, EventArgs e)
        {
            var elem = sender as FrameworkElement;
            SetDataContextFromAncestorOfType(elem, GetDataContextFromAncestor(elem) as Type);
            elem.Loaded -= loadedHandler;
        }
    }
    //a helper class to find the first ancestor of some Type
    public static class ElementExtension
    {
        public static DependencyObject FindAncestorOfType(this DependencyObject o, Type ancestorType)
        {            
            var parent = VisualTreeHelper.GetParent(o);
            if (parent != null)
            {
                if (parent.GetType().IsSubclassOf(ancestorType) || parent.GetType() == ancestorType)
                {
                    return parent;
                }
                return FindAncestorOfType(parent, ancestorType);
            }
            return null;
        }
    }
