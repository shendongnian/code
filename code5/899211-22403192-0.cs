    //I assume your listbox selection changed is ListBoxImage_Selectionchange
    //ListBoxImage is your ListBox name
    // LastSelectedIndex define globally
    int LastSelectedIndex =0;
    
    private void  ListBoxImage_Selectionchange(object sender, SelectionChangedEventArgs e)
        {
              if (ListBoxImage.SelectedIndex == -1)
                        return;
           if(LastSelectedIndex>0)
             {
                ListBoxItem lastItem =this.ListImage.ItemContainerGenerator.ContainerFromIndex(LastSelectedIndex) as ListBoxItem;
               Image lastImage = FindFirstElementInVisualTree<Image>(lastItem);
               lastImage.Opacity = 0.5;
             }
        
              ListBoxItem selectedItem = this.ListImage.ItemContainerGenerator.ContainerFromIndex(ListImage.SelectedIndex) as ListBoxItem;
              Image selectedImage = FindFirstElementInVisualTree<Image>(selectedItem);
              selectedImage.Opacity = 1.0; 
              LastSelectedIndex = ListBoxImage.SelectedIndex;
              ListImage.SelectedIndex = -1;
        }
    
        private T FindFirstElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
                {
                    var count = VisualTreeHelper.GetChildrenCount(parentElement);
                    if (count == 0)
                        return null;
        
                    for (int i = 0; i < count; i++)
                    {
                        var child = VisualTreeHelper.GetChild(parentElement, i);
        
                        if (child != null && child is T)
                        {
                            return (T)child;
                        }
                        else
                        {
                            var result = FindFirstElementInVisualTree<T>(child);
                            if (result != null)
                                return result;
        
                        }
                    }
                    return null;
                }
