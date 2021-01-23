    class SearchProperties
    {
        #region DialogResult
    
        public static readonly DependencyProperty ItemToScrollIntoViewProperty =
            DependencyProperty.RegisterAttached("ItemToScrollIntoView", typeof(int?), typeof(SearchBehaviours), new PropertyMetadata(default(int?), OnItemToScrollIntoViewChanged));
    
        private static void OnItemToScrollIntoViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dg = d as DataGrid;
            if (dg == null)
                return;
    
            if (dg.Items.Count < 1)
                return;
    
            if (e.NewValue == null)
                return;
    
            int? new_value = (int?)e.NewValue;
            if (new_value != null)
            {
                int nonNullValue = new_value.GetValueOrDefault() - 1;
                object item = dg.Items[nonNullValue];
                dg.SelectedIndex = nonNullValue;
                dg.ScrollIntoView(item);
            }
        }
    
        public static int? GetItemToScrollIntoView(DependencyObject dp)
        {
            if (dp == null) throw new ArgumentNullException("dp");
    
            return (int?)dp.GetValue(ItemToScrollIntoViewProperty);
        }
    
        public static void SetItemToScrollIntoView(DependencyObject dp, object value)
        {
            if (dp == null) throw new ArgumentNullException("dp");
    
            dp.SetValue(ItemToScrollIntoViewProperty, value);
        }
    
        #endregion
    }
