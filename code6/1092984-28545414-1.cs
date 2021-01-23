            var currentPage = ((PhoneApplicationFrame)Application.Current.RootVisual).Content as PhoneApplicationPage;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(currentPage); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(currentPage, i);
                
                if (child is System.Windows.Controls.Control)
                {
                    // do work
                }
                else if (child is System.Windows.FrameworkElement)
                {
                    // do work
                }
                if (VisualTreeHelper.GetChildrenCount(child) > 0)
                {
                    enumChildren(child); // recur. enumerate children
                }
            }
