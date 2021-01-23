    private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
     if (e.Key == Key.Enter)
      {
       var txt= sender as TextBox;
       var selecteditem=FindParent<ListBoxItem>(txt);
       int index = ListBox.ItemContainerGenerator.IndexFromContainer(selecteditem);
       if(index<ListBox.Items.Count)
        {
        var afterItem=(ListBoxItem)ListBox.ItemContainerGenerator.ContainerFromIndex(index+1);
        TextBox tbFind = GetDescendantByType(afterItem, typeof (TextBox), "TextBox") as TextBox;
        if (tbFind != null)
        {
         FocusHelper.Focus(tbFind);
        }
       }
      }
    }
    public static Visual GetDescendantByType(Visual element, Type type, string name)
    {
     if (element == null) return null;
     if (element.GetType() == type)
     {
      FrameworkElement fe = element as FrameworkElement;
      if (fe != null)
      {
         if (fe.Name == name)
         {
            return fe;
         }
      }
     }
    Visual foundElement = null;
    if (element is FrameworkElement)
      (element as FrameworkElement).ApplyTemplate();
    for (int i = 0;
        i < VisualTreeHelper.GetChildrenCount(element);
        i++)
    {
      Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
      foundElement = GetDescendantByType(visual, type, name);
      if (foundElement != null)
         break;
    }
    return foundElement;
    }
    public static T FindParent<T>(DependencyObject child) where T : DependencyObject
    {
     //get parent item
    DependencyObject parentObject = VisualTreeHelper.GetParent(child);
    //we've reached the end of the tree
    if (parentObject == null) return null;
    //check if the parent matches the type we're looking for
    T parent = parentObject as T;
    if (parent != null)
        return parent;
    else
        return FindParent<T>(parentObject);
    }
