        public static int GetGridRow(DependencyObject obj)
        {
            return (int)obj.GetValue(GridRowProperty);
        }
        public static void SetGridRow(DependencyObject obj, int value)
        {
            obj.SetValue(GridRowProperty, value);
        }
        // Using a DependencyProperty as the backing store for GridRow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridRowProperty =
            DependencyProperty.RegisterAttached("GridRow", typeof(int), typeof(ViewModel), new PropertyMetadata(0));
