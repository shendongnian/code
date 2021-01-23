        private void panel_Touch(object sender, RoutedEventArgs e)
        {
            int index;
            var button = sender as Button;
            if (button != null)
            {
                var contentPresenter = VisualTreeHelper.GetParent(button) as ContentPresenter;
                if (contentPresenter != null)
                {
                    var stackPanel = VisualTreeHelper.GetParent(contentPresenter) as StackPanel;
                    if (stackPanel != null)
                        index = stackPanel.Children.IndexOf(contentPresenter);
                }
            }
        }
