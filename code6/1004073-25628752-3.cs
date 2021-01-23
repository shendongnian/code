    public class MyFrameworkObject : DependencyObject
    {
        public static readonly DependencyProperty RuntimeFrameWorkElementProperty = DependencyProperty.RegisterAttached("RuntimeFrameWorkElement", typeof(FrameworkElement), typeof(MyFrameworkObject),new PropertyMetadata(new PropertyChangedCallback(OnPropertyChanged)));
        static void  OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetRuntimeFrameWorkElement(d as UIElement, e.NewValue as FrameworkElement);
        }
        public static void SetRuntimeFrameWorkElement(UIElement element, FrameworkElement value)
        {
            if (element!=null && value != null && value.Parent == null) //The loaded Control can be added to only one Control because its Parent will be set
            {
                var panel = element as Panel;
                if (panel != null)
                {
                    panel.Children.Add(value);
                    return;
                }
                var contentControl = element as ContentControl;
                if (contentControl != null)
                    contentControl.Content = value;
                //TODO:ItemsControl
            }
        }
    }
