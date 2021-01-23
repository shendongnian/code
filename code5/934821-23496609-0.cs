     public static void CheckAllTreeItemsAuto(RadTreeView tree)
            {
                tree.ItemContainerGenerator.StatusChanged += (s, e) =>
                {
                    if ((s as Telerik.Windows.Controls.ItemContainerGenerator).Status == Telerik.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
                    {
                        RadTreeViewItem item = (RadTreeViewItem)tree.ItemContainerGenerator.ContainerFromIndex(0);
                        while (item != null)
                        {
                            item.IsChecked = true;
                            item = item.NextItem;
                        }
                    }
    
                };
    
            }
