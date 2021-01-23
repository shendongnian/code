    public static class MyStyles
    {
        static FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata(
                                         string.Empty, FrameworkPropertyMetadataOptions.AffectsRender, MyStylePropertyChangeCallBack);
    
        public static readonly DependencyProperty MyStyleProperty =
            DependencyProperty.RegisterAttached("MyStyle", typeof (String), typeof (MyStyles), metadata);
    
        public static void SetStyleName(UIElement element, string value)
        {
            element.SetValue(MyStyleProperty, value);
        }
        public static Boolean GetStyleName(UIElement element)
        {
            return (Boolean)element.GetValue(MyStyleProperty);
        }
    
    
        public static void MyStylePropertyChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
    
            FrameworkElement ctrl = d as FrameworkElement;
    
            if (ctrl.IsLoaded)
            {
                string styleName = Convert.ToString(e.NewValue);
                if (!string.IsNullOrEmpty(styleName))
                {
                    ctrl.Style = ctrl.TryFindResource(styleName) as Style;
                }
            }
        }
    }
