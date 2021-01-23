     DependencyObject findElementInItemsControlItemAtIndex(ItemsControl itemsControl,
                                                                  int itemOfIndexToFind,
                                                                  string nameOfControlToFind)
            {
                if (itemOfIndexToFind >= itemsControl.Items.Count) return null;
    
                DependencyObject depObj = null;
                object o = itemsControl.Items[itemOfIndexToFind];
                if (o != null)
                {
                    var item = itemsControl.ItemContainerGenerator.ContainerFromItem(o);
                    if (item != null)
                    {
                        depObj = getVisualTreeChild(item, nameOfControlToFind);
                        return depObj;
                    }
                }
                return null;
            }
    
    
            DependencyObject getVisualTreeChild(DependencyObject obj, String name)
            {
                DependencyObject dependencyObject = null;
                int childrenCount = VisualTreeHelper.GetChildrenCount(obj);
                for (int i = 0; i < childrenCount; i++)
                {
                    var oChild = VisualTreeHelper.GetChild(obj, i);
                    var childElement = oChild as FrameworkElement;
                    if (childElement != null)
                    {
                        //Code to take care of Paragraph/Run
                        if (childElement is RichTextBlock || childElement is TextBlock)
                        {
                            dependencyObject = childElement.FindName(name) as DependencyObject;
                            if (dependencyObject != null)
                                return dependencyObject;
                        }
    
                        if (childElement.Name == name)
                        {
                            return childElement;
                        }
                    }
                    dependencyObject = getVisualTreeChild(oChild, name);
                    if (dependencyObject != null)
                        return dependencyObject;
                }
                return dependencyObject;
            }
    
                      
            private void Category_ListViewDetail_Loaded(object sender, RoutedEventArgs e)
            {
                ListView ListViewObject = sender as ListView;
    
                //For changing Detail Sub Categories Width:
                
                int CategoriesCount = ListViewObject.Items.Count;
    
                for (int i = 0; i < CategoriesCount; i++)
                {
                    TextBlock SubCategory_TextBlockObject = findElementInItemsControlItemAtIndex(ListViewObject, i, "SubCategoryName_TextBlock") as TextBlock;
                    if (SubCategory_TextBlockObject != null)
                    {
                        SubCategory_TextBlockObject.Width = Window.Current.Bounds.Width - 50;
    
                    }
                }
    
                for (int i = 0; i < CategoriesCount; i++)
                {
                    TextBlock Category_TextBlockObject = findElementInItemsControlItemAtIndex(ListViewObject, i, "CategoryName_InDetailView_Textblock") as TextBlock;
                    if (Category_TextBlockObject != null)
                    {
                        Category_TextBlockObject.Width = Window.Current.Bounds.Width - 30;
    
                    }
                }
    
    
            
            }
    
    
            private void Category_ListViewSummary_Loaded(object sender, RoutedEventArgs e)
            {
                //For changing Summary Categories Width:
    
                ListView ListViewObject = sender as ListView;
    
                int CategoriesCount = GetCategoriesResultObject.MasterCategories[0].Categories.Count;
    
                for(int i=0;i<CategoriesCount;i++)
                {
                    TextBlock Category_TextBlockObject = findElementInItemsControlItemAtIndex(ListViewObject, i, "CategoryName_Textblock") as TextBlock;
                        if (Category_TextBlockObject != null)
                        {
                            Category_TextBlockObject.Width = Window.Current.Bounds.Width - 30;
                        }
                }
              
            }
