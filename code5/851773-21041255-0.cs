    public static readonly DependencyProperty LinkedScrollViewerProperty = DependencyProperty.RegisterAttached("LinkedScrollViewer", typeof(ScrollViewer), typeof(ScrollViewerProperties), new UIPropertyMetadata(null, OnLinkedScrollViewerChanged));
    public static ScrollViewer GetLinkedScrollViewer(DependencyObject dependencyObject)
    {
        return (ScrollViewer)dependencyObject.GetValue(LinkedScrollViewerProperty);
    }
    public static void SetLinkedScrollViewer(DependencyObject dependencyObject, ScrollViewer value)
    {
        dependencyObject.SetValue(LinkedScrollViewerProperty, value);
    }
    public static void OnLinkedScrollViewerChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        ScrollViewer scrollViewer = (ScrollViewer)dependencyObject;
        ScrollViewer newLinkedScrollViewer = e.NewValue as ScrollViewer;
        if (newLinkedScrollViewer != null)
        {
            newLinkedScrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset);
            newLinkedScrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset);
        }
    }
