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
            // Additionnaly, initialize the instance DropHandler :
            var handler = (IDropHandler)(e.NewValue);
            Instance.DropHandler = handler;
        }
        private void ElementOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var element = (UIElement)sender;
            element.ReleaseMouseCapture();
            this.elementStartPosition.X = this.Transform.X;
            this.elementStartPosition.Y = this.Transform.Y;
            // this is the main change
            if (this.DropHandler != null)
            {
                this.DropHandler.Dropped(this.Transform.X, this.Transform.Y);
            }
        }
