    class MarkerCanvas : Canvas
    {
        public DataGrid Grid
        {
            get { return (DataGrid)GetValue(GridProperty); }
            set { SetValue(GridProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Grid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridProperty =
            DependencyProperty.Register("Grid", typeof(DataGrid), typeof(MarkerCanvas), new PropertyMetadata(null, OnGridChanged));
        private static void OnGridChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MarkerCanvas canvas = d as MarkerCanvas;
            if (e.NewValue != null)
            {
                (e.NewValue as DataGrid).SelectionChanged += canvas.MarkerCanvas_SelectionChanged;
            }
            if (e.OldValue != null)
            {
                (e.NewValue as DataGrid).SelectionChanged -= canvas.MarkerCanvas_SelectionChanged;
            }
        }
        void MarkerCanvas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InvalidateVisual();
        }
        public Brush MarkerBrush
        {
            get { return (Brush)GetValue(MarkerBrushProperty); }
            set { SetValue(MarkerBrushProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MarkerBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MarkerBrushProperty =
            DependencyProperty.Register("MarkerBrush", typeof(Brush), typeof(MarkerCanvas), new PropertyMetadata(Brushes.SlateGray));
        protected override void OnRender(System.Windows.Media.DrawingContext dc)
        {
            base.OnRender(dc);
            if (Grid==null || Grid.SelectedItems == null)
                return;
            object[] markers = Grid.SelectedItems.OfType<object>().ToArray();
            double translateDelta = ActualHeight / (double)Grid.Items.Count;
            double width = ActualWidth;
            double height = Math.Max(translateDelta, 4);
            Brush dBrush = MarkerBrush;
            for (int i = 0; i < markers.Length; i++)
            {
                double itemIndex = Grid.Items.IndexOf(markers[i]);
                double top = itemIndex * translateDelta;
                dc.DrawRectangle(dBrush, null, new Rect(0, top, width, height));
            }
        }
    }
