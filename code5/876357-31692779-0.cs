    private TreeViewItem GetParent(TreeViewItem root, TreeViewItem child)
        {
            //Step 1: Search at current level
            foreach (TreeViewItem item in root.Items)
            {
                if (item.GetHashCode() == child.GetHashCode())
                {
                    return root;
                }
            }
            //Step 2: Still not found, so step deeper
            TreeViewItem buffer;
            foreach (TreeViewItem item in root.Items)
            {
                buffer = GetParent(item, child);
                if (buffer != null)
                {
                    return buffer;
                }
            }
            //Not found anything
            return null;
        }
