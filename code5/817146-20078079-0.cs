    public class MouseClick
    {
        public static readonly DependencyProperty MouseLeftClickProperty = 
            DependencyProperty.RegisterAttached("MouseLeftClick", typeof(ICommand), typeof(MouseClick),
            new FrameworkPropertyMetadata(CallBack));
        public static void SetMouseLeftClick(DependencyObject sender, ICommand value)
        {
            sender.SetValue(MouseLeftClickProperty, value);
        }
        public static ICommand GetMouseLeftClick(DependencyObject sender)
        {
            return sender.GetValue(MouseLeftClickProperty) as ICommand;
        }
        public static readonly DependencyProperty MouseEventParameterProperty =
            DependencyProperty.RegisterAttached(
                "MouseEventParameter",
                typeof(object),
                typeof(MouseClick),
                new FrameworkPropertyMetadata((object)null, null));
        public static object GetMouseEventParameter(DependencyObject d)
        {
            return d.GetValue(MouseEventParameterProperty);
        }
        public static void SetMouseEventParameter(DependencyObject d, object value)
        {
            d.SetValue(MouseEventParameterProperty, value);
        }
        private static void CallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null)
            {
                UIElement element = sender as UIElement;
                if (element != null)
                {
                    if (e.OldValue != null)
                    {
                        element.RemoveHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(Handler));
                    }
                    if (e.NewValue != null)
                    {
                        element.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(Handler), true);
                    }
                }
            }
        }
        private static void Handler(object sender, EventArgs e)
        {
            UIElement element = sender as UIElement;
            if (sender != null)
            {
                ICommand cmd = element.GetValue(MouseLeftClickProperty) as ICommand;
                if (cmd != null)
                {
                    RoutedCommand routedCmd =cmd as RoutedCommand;
                    object paramenter = element.GetValue(MouseEventParameterProperty);
                    if (paramenter == null)
                    {
                        paramenter = element;
                    }
                    if (routedCmd != null)
                    {
                        if (routedCmd.CanExecute(paramenter, element))
                        {
                            routedCmd.Execute(paramenter, element);
                        }
                    }
                    else
                    {
                        if (cmd.CanExecute(paramenter))
                        {
                            cmd.Execute(paramenter);
                        }
                    }
                }
            }
        }
    }
