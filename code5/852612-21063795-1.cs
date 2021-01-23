        void GridView_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            GridView gridView = sender as GridView;
            FrameworkElement root = Window.Current.Content as FrameworkElement;
            Point position = gridView.TransformToVisual(root).TransformPoint(e.GetCurrentPoint(gridView).Position);
            // check items directly under the pointer
            foreach (var element in VisualTreeHelper.FindElementsInHostCoordinates(position, root))
            {
                var context = ((FrameworkElement)element).DataContext;
            }
        }
