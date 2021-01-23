        public TreeViewItem GetTreeViewItem(ItemsControl cont, object item)
        {
            if(cont != null)
            {
                if (cont.DataContext == item)
                    return cont as TreeViewItem;
                    
                cont.ApplyTemplate();
                ItemsPresenter itemsPres = (ItemsPresenter)cont.Template.FindName("ItemsHost", cont);
                if (itemsPres != null)
                    itemsPres.ApplyTemplate();
                else
                {
                    itemsPres = FindVisualChild<ItemsPresenter>(cont);
                    if(itemsPres == null)
                    {
                        cont.UpdateLayout();
                        itemsPres = FindVisualChild<ItemsPresenter>(cont);
                    }
                }
                System.Windows.Controls.Panel itemsHostPanel = (System.Windows.Controls.Panel)VisualTreeHelper.GetChild(itemsPres, 0);
                UIElementCollection children = itemsHostPanel.Children;
                for(int i = 0, count = cont.Items.Count; i < count; ++i)
                {
                    TreeViewItem subCont;
                    subCont = (TreeViewItem)cont.ItemContainerGenerator.ContainerFromIndex(i);
                    if(subCont != null)
                    {
                        TreeViewItem result = GetTreeViewItem(subCont, item);
                        if (result != null)
                            return result;
                    }
                }
            }
            return null;
        }
