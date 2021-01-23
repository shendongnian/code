    protected virtual void PrepareContainerForItemOverride(DependencyObject element, Object item)
    {
        // get the attached property from the ItemsControl item
        string header = ((FrameworkElement)item).GetValue(GroupLayout.Header) as string;
        // set the container's "Header"
        ((HeaderedContentControl)element).Header = header;
    }
