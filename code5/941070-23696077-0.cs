        void DirSearch(string sDir, TreeViewItem parentItem)
        {
            ......
            foreach (string d in Directory.GetDirectories(sDir))
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = d;
                foreach (string f in Directory.GetFiles(d, "*.resx"))
                {
                    TreeViewItem subitem = new TreeViewItem();
                    subitem.Header = f;
                    subitem.Tag = f;
                    item.Items.Add(subitem);
                }
                DirSearch(d, item);
                if (item.Items.Count > 0)
                    parentItem.Items.Add(item);
            }
            ......
        }
