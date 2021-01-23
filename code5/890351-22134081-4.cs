        public AnItemsControl()
        {
            DefaultStyleKey = typeof(AnItemsControl);
            Loaded += AnItemsControl_Loaded;
        }
        private void AnItemsControl_Loaded(object sender, RoutedEventArgs e)
        {
            TypedPanel = FindItemsPanel<SlideContentPanel>(this);
        }
        private T FindItemsPanel<T>(FrameworkElement visual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                FrameworkElement child = VisualTreeHelper.GetChild(visual, i) as FrameworkElement;
                if (child != null)
                {
                    if (child is T && VisualTreeHelper.GetParent(child) is ItemsPresenter)
                    {
                        object temp = child;
                        return (T)temp;
                    }
                    T panel = FindItemsPanel<T>(child);
                    if (panel != null)
                    {
                        object temp = panel;
                        return (T)temp;
                    }
                }
            }
            return default(T);
        }
