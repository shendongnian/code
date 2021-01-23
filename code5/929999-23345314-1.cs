    public class DragDropAttProps
    {
        public static readonly DependencyProperty ScrollOnDragDropProperty =
            DependencyProperty.RegisterAttached(
                "ScrollOnDragDrop",
                typeof(bool),
                typeof(DragDropAttProps),
                new PropertyMetadata(false, HandleScrollOnDragDropChanged));
        public static bool GetScrollOnDragDrop(DependencyObject element)
        {
            return (bool)element.GetValue(ScrollOnDragDropProperty);
        }
        public static void SetScrollOnDragDrop(DependencyObject element, bool value)
        {
            element.SetValue(ScrollOnDragDropProperty, value);
        }
        private static void HandleScrollOnDragDropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var container = d as FrameworkElement;
            if (d == null)
            {
                Debug.Fail("Invalid type!");
            }
 
            Unsubscribe(container);
 
            if (true.Equals(e.NewValue))
            {
                Subscribe(container);
            }
        }
        private static void Subscribe(FrameworkElement container)
        {
            container.PreviewDragOver += OnContainerPreviewDragOver;
        }
        private static void Unsubscribe(FrameworkElement container)
        {
            container.PreviewDragOver -= OnContainerPreviewDragOver;
        }
        private static void OnContainerPreviewDragOver(object sender, DragEventArgs e)
        {
            const double Tolerance = 60;
            const double Offset = 20;
            var container = sender as FrameworkElement;
            if (container == null)
            {
                return;
            }
 
            var scrollViewer = GetFirstVisualChild<ScrollViewer>(container); 
            if (scrollViewer == null)
            {
                return;
            }
 
            var verticalPos = e.GetPosition(container).Y;
            if (verticalPos < Tolerance)
            {
                // Top of visible list? Scroll up.
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - Offset);
            }
            else if (verticalPos > container.ActualHeight - Tolerance) 
            {
                // Bottom of visible list? Scroll down.
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + Offset);
            }
        }
        private static T GetFirstVisualChild<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i);
                    if (child is T)
                    {
                        return (T)child;
                    }
 
                    var childItem = GetFirstVisualChild<T>(child);
                    if (childItem != null)
                    {
                        return childItem;
                    }
                }
            }
 
            return null;
        }
    }
