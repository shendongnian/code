    public static class TreeViewExt
    {
         public static void ExpandRecursively(this ItemsControl itemsControl, bool expand, int levelDepth)
        {
            int depth = levelDepth == int.MaxValue ? levelDepth : levelDepth - 1;
           TreeViewItem treeViewItem = itemsControl as TreeViewItem;
            if (treeViewItem != null)
                treeViewItem.IsExpanded = expand || levelDepth >= 0; // expand, or keep expanded when levelDepth >= 0
             if (levelDepth > 0 || !expand)
            {
                // get container generator of itemsControl
                ItemContainerGenerator itemContainerGenerator = itemsControl.ItemContainerGenerator;
                 // if containers have already been generated, the subItems can be expanded/collapsed
                if (itemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                {
                    for (int i = itemsControl.Items.Count - 1; i >= 0; --i)
                    {
                        ItemsControl childControl = itemContainerGenerator.ContainerFromIndex(i) as ItemsControl;
                        if (childControl != null)
                            childControl.ExpandRecursively(expand, depth);
                    }
                } 
                else
                {
                    EventHandler handler = null; // store in variable, so the handler can be detached
                    handler = new EventHandler((s, e) =>
                    {
                        if (itemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                        {
                            for (int i = itemsControl.Items.Count - 1; i >= 0; --i)
                            {
                                ItemsControl childControl = itemContainerGenerator.ContainerFromIndex(i) as ItemsControl;
                                if (childControl != null)
                                    childControl.ExpandRecursively(expand, depth);
                                itemContainerGenerator.StatusChanged -= handler; // detach
                            }
                        }
                    });
                    itemContainerGenerator.StatusChanged += handler; // attach
                }
            }
        }
    }
