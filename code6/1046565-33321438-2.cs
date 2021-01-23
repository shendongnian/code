        public ObservableCollection<Rect> Gaps
        {
            get { return (ObservableCollection<Rect>)GetValue(GapsProperty); }
            set { SetValue(GapsProperty, value); }
        }
        private static FrameworkPropertyMetadata fpm = new FrameworkPropertyMetadata(
            null,
            FrameworkPropertyMetadataOptions.AffectsRender |
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            null,
            null
        );
        public static readonly DependencyProperty GapsProperty =
            DependencyProperty.Register("Gaps", typeof(ObservableCollection<Rect>), typeof(OverlayWithGaps), fpm);
