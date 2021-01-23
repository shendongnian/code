    public static class MyClass
    {
        public static void SetParent(DependencyObject obj, Button val)
        {
            obj.SetValue(ParentProperty, val);
        }
        public static Button GetParent(DependencyObject obj)
        {
            return (Button)obj.GetValue(ParentProperty);
        }
        public static readonly DependencyProperty ParentProperty = DependencyProperty.RegisterAttached("Parent", typeof(Button), typeof(MyClass), new PropertyMetadata(null, new PropertyChangedCallback(
            (x, y) =>
            {
                Debug.WriteLine(GetParent(x));
            })));
        public static void SetContent(DependencyObject obj, string val)
        {
            obj.SetValue(ContentProperty, val);
        }
        public static string GetContent(DependencyObject obj)
        {
            return (string)obj.GetValue(ContentProperty);
        }
        public static readonly DependencyProperty ContentProperty = DependencyProperty.RegisterAttached("Content", typeof(string), typeof(MyClass), new PropertyMetadata(null, new PropertyChangedCallback(
            (x, y) =>
            {
                if (GetContent(x) != String.Empty)
                    ((Button)GetParent(x)).Content = GetContent(x);
            })));
    }
