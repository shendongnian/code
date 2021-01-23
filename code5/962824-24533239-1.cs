    private void lvAllowDropListView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {   
            System.Windows.Forms.ToolStripMenuItem button = e.Data.GetData(typeof(System.Windows.Forms.ToolStripMenuItem))
                           as System.Windows.Forms.ToolStripMenuItem;
            if (button != null)
                {
            try
            {
                SmallImageList = sysIcons.SmallIconsImageList;
                LargeImageList = sysIcons.LargeIconsImageList;
                System.Windows.Forms.ToolStripMenuItem item = e.Data.GetData(typeof(System.Windows.Forms.ToolStripMenuItem))
                           as System.Windows.Forms.ToolStripMenuItem;
                if (item != null)
                {
                    AddToolStripMenuItem(item.Text, item.Name);
                }
            }
            catch { }
                }
        }
        private void AddToolStripMenuItem(string name, string tag)
        {
            System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(name);
            int Index = -1;
            for (int i = 0; i < Items.Count;i++ )
                if(Items[i].Tag.ToString() == tag)
                {
                    Index = i;
                    break;
                }
                if (Index == -1)
                {
                    item.Tag = tag;
                    Items.Add(item);
                }
        }
