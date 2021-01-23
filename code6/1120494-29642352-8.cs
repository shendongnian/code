    private void HeaderGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CheckState();
        }
        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var value = (sender as FrameworkElement).DataContext;
            CheckState();
        }
        private void CheckState()
        {
            if ((ContentGrid.RenderTransform as CompositeTransform).ScaleY > 0)
                VisualStateManager.GoToState(this, "Collapsed", true);
            else
                VisualStateManager.GoToState(this, "Expanded", true);
        }
