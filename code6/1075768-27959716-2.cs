        public static readonly DependencyProperty DropHandlerProperty =
            DependencyProperty.RegisterAttached(
                "DropHandler",
                typeof(IDropHandler),
                typeof(DragOnCanvasBehavior),
                new PropertyMetadata(OnDropHandlerChanged));
        private IDropHandler DropHandler { get; set; }
        public static IDropHandler GetDropHandler(UIElement target)
        {
            return (IDropHandler)target.GetValue(DropHandlerProperty);
        }
        public static void SetDropHandler(UIElement target, IDropHandler value)
        {
            target.SetValue(DropHandlerProperty, value);
        }
        private static void OnDropHandlerChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Initialize variables and assign handlers
            // see original code in Github linked in original question
            // Additionnaly, initialize the DropHandler :
            var handler = (IDropHandler)(e.NewValue);
            Instance.DropHandler = handler;
        }
        private void ElementOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var element = (UIElement)sender;
            element.ReleaseMouseCapture();
            // this is the main change
            if (this.DropHandler != null)
            {
                this.DropHandler.Dropped();
            }
        }
        private void ElementOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            // TODO : do some calculations
            this.DropHandler.Moved(x, y);
        }
