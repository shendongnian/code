    public static readonly DependencyProperty PreviewMouseLeftButtonDownCommandProperty =
            DependencyProperty.RegisterAttached("PreviewMouseLeftButtonDownCommand", typeof (ICommand),
                typeof (MouseBehaviour), new FrameworkPropertyMetadata(PreviewMouseLeftButtonDownCommandChanged));
        private static void PreviewMouseLeftButtonDownCommandChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            var element = (FrameworkElement) dependencyObject;
            element.PreviewMouseLeftButtonDown += Element_PreviewMouseLeftButtonDown;
        }
        private static void Element_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs args)
        {
            var element = (FrameworkElement) sender;
            ICommand command = GetPreviewMouseLeftButtonDownCommand(element);
            if (command != null)
            {
                command.Execute(args);
            }
        }
        public static void SetPreviewMouseLeftButtonDownCommand(UIElement element, ICommand value)
        {
            element.SetValue(PreviewMouseLeftButtonDownCommandProperty, value);
        }
        public static ICommand GetPreviewMouseLeftButtonDownCommand(UIElement element)
        {
            return (ICommand) element.GetValue(PreviewMouseLeftButtonDownCommandProperty);
        } 
