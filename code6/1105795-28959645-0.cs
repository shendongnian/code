    private void PreviewDragOver(object sender, DragEventArgs e)
    {
        HitTestResult hitTestResult = 
            VisualTreeHelper.HitTest(sender, e.GetPosition(sender));
        DataGridRow dataGridRowUnderMouse = 
            GetParentOfType<DataGridRow>(hitTestResult.VisualHit);
        // Do something with dataGridRowUnderMouse 
    }
    private T GetParentOfType<T>(DependencyObject element) where T : DependencyObject
    {
        Type type = typeof(T);
        if (element == null) return null;
        DependencyObject parent = VisualTreeHelper.GetParent(element);
        if (parent == null && ((FrameworkElement)element).Parent is DependencyObject) 
            parent = ((FrameworkElement)element).Parent;
        if (parent == null) return null;
        else if (parent.GetType() == type || parent.GetType().IsSubclassOf(type)) 
            return parent as T;
        return GetParentOfType<T>(parent);
    }
