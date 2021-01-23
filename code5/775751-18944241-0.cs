    foreach (var item in MainCanvas.Items)
    {
            DependencyObject icg = MainCanvas.ItemContainerGenerator.ContainerFromItem(item);
            (icg as FrameworkElement).Tap += MainItem_Tap;
    }
