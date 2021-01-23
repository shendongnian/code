     public class AdaptableGridView : GridView
        {
            // default itemWidth
            private const double itemWidth = 100.00;
            public double ItemWidth
            {
                get { return (double)GetValue(ItemWidthProperty); }
                set { SetValue(ItemWidthProperty, value); }
            }
            public static readonly DependencyProperty ItemWidthProperty =
                DependencyProperty.Register("ItemWidth", typeof(double), typeof(AdaptableGridView), new PropertyMetadata(itemWidth));
        // default max number of rows or columns
        private const int maxRowsOrColumns = 3;
        public int MaxRowsOrColumns
        {
            get { return (int)GetValue(MaxRowColProperty); }
            set { SetValue(MaxRowColProperty, value); }
        }
        public static readonly DependencyProperty MaxRowColProperty =
            DependencyProperty.Register("MaxRowsOrColumns", typeof(int), typeof(AdaptableGridView), new PropertyMetadata(maxRowsOrColumns));
        public AdaptableGridView()
        {
            this.SizeChanged += MyGridViewSizeChanged;
        }
        private void MyGridViewSizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Calculate the proper max rows or columns based on new size 
            this.MaxRowsOrColumns = this.ItemWidth > 0 ? Convert.ToInt32(Math.Floor(e.NewSize.Width / this.ItemWidth)) : maxRowsOrColumns;
        }
    }
