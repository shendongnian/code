    public sealed class ExtendedListView : ListView
    {
        public ExtendedListView()
        {
            this.DefaultStyleKey = typeof(ExtendedListView);
        }
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            ListViewItem lvi = element as ListViewItem;
            lvi.Loaded += lvi_Loaded;
        }
        void lvi_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewItem lvi = sender as ListViewItem;
            ApplyCallbacksToElement(lvi.ContentTemplateRoot);
        }
        private void ApplyCallbacksToElement(DependencyObject element)
        {
            if (null != element)
            {
                int childrenCount = VisualTreeHelper.GetChildrenCount(element);
                for (int i = 0; i < childrenCount; i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(element, i);
                    // Code for adding element callbacks goes here
                    //
                    // For example:
                    // if (IsButtonAndMatchesCondition(child))
                    // {
                    //     (child as Button).Click += button_Click;
                    // }
                    //
                    ApplyCallbacksToElement(child);
                }
            }
        }
    }
