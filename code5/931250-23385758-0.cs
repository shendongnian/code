    public class X<T>
    {
        public static ObservableCollection<T> GetCollection(DependencyObject obj)
        {
            return (ObservableCollection<T>)obj.GetValue(CollectionProperty);
        }
        public static void SetCollection(DependencyObject obj, ObservableCollection<T> value)
        {
            obj.SetValue(CollectionProperty, value);
        }
        // Using a DependencyProperty as the backing store for Collection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CollectionProperty =
            DependencyProperty.RegisterAttached("Collection", typeof(ObservableCollection<T>), typeof(X<T>), new PropertyMetadata(null));
    }
    public class XInt : X<int> { }
