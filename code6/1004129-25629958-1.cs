        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems.Clear();
            foreach (var p in productList)
            {
                var itemName = p.Name;
                var item = (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems.Add(itemName, null, SelectedPreset);
                item.Tag = p;
            }
        }
        private void SelectedPreset(object sender, EventArgs e)
        {
            var menuItem = (ToolStripItem)sender;
            Debug.WriteLine(((Product)menuItem.Tag).Name);
        }
