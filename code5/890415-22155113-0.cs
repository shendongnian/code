    private void SearchVisualTree(DependencyObject targetElement, string _imageTag)
    {
      var count = VisualTreeHelper.GetChildrenCount(targetElement);
      if (count == 0)
      return;
 
    for (int i = 0; i < count; i++)
    {
        var child = VisualTreeHelper.GetChild(targetElement, i);
        if (child is Image)
        {
            Image targetItem = (Image)child;
             
            if (targetItem.Tag as string == _imageTag && targetItem.Visibility == Visibility.Visible)
            {
                targetItem.Visibility = Visibility.Collapsed;
                return;
            }
        }
        else
        {
            SearchVisualTree(child, _imageTag);
        }
      }
    }
