    public class ItemsRenderer : FrameworkElement
    {
        private bool _isLoaded;
        public ItemsRenderer()
        {
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _isLoaded = true;
            if (IsAnimating)
            {
                Start();
            }
        }
        private void OnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _isLoaded = false;
            Stop();
        }
        public bool IsAnimating
        {
            get { return (bool)GetValue(IsAnimatingProperty); }
            set { SetValue(IsAnimatingProperty, value); }
        }
        public static readonly DependencyProperty IsAnimatingProperty =
            DependencyProperty.Register("IsAnimating", typeof(bool), typeof(ItemsRenderer), new FrameworkPropertyMetadata(false, (d, e) => ((ItemsRenderer)d).OnIsAnimatingChanged((bool)e.NewValue)));
        private void OnIsAnimatingChanged(bool isAnimating)
        {
            if (_isLoaded)
            {
                Stop();
                if (isAnimating)
                {
                    Start();
                }
            }
        }
        private void Start()
        {
            CompositionTarget.Rendering += CompositionTargetOnRendering;
        }
        private void Stop()
        {
            CompositionTarget.Rendering -= CompositionTargetOnRendering;
        }
        private void CompositionTargetOnRendering(object sender, EventArgs eventArgs)
        {
            InvalidateVisual();
        }
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof (ImageSource), typeof (ItemsRenderer), new FrameworkPropertyMetadata());
        public ImageSource ImageSource
        {
            get { return (ImageSource) GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public static readonly DependencyProperty ImageSizeProperty =
            DependencyProperty.Register("ImageSize", typeof(Size), typeof(ItemsRenderer), new FrameworkPropertyMetadata(Size.Empty));
        public Size ImageSize
        {
            get { return (Size) GetValue(ImageSizeProperty); }
            set { SetValue(ImageSizeProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof (IEnumerable), typeof (ItemsRenderer), new FrameworkPropertyMetadata());
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable) GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        protected override void OnRender(DrawingContext dc)
        {
            ImageSource imageSource = ImageSource;
            IEnumerable itemsSource = ItemsSource;
            if (itemsSource == null || imageSource == null) return;
            Size size = ImageSize.IsEmpty ? new Size(imageSource.Width, imageSource.Height) : ImageSize;
            foreach (var item in itemsSource)
            {
                dc.DrawImage(imageSource, new Rect(GetPoint(item), size));
            }
        }
        private Point GetPoint(object item)
        {
            var args = new ItemPointEventArgs(item);
            OnPointRequested(args);
            return args.Point;
        }
        public event EventHandler<ItemPointEventArgs> PointRequested;
        protected virtual void OnPointRequested(ItemPointEventArgs e)
        {
            EventHandler<ItemPointEventArgs> handler = PointRequested;
            if (handler != null) handler(this, e);
        }
    }
    public class ItemPointEventArgs : EventArgs
	{
        public ItemPointEventArgs(object item)
        {
            Item = item;
        }
        public object Item { get; private set; }
        public Point Point { get; set; }
	}
