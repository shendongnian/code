        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems.Clear();
            (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItemClicked -= DropDownItemClicked;
            (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItemClicked += DropDownItemClicked;
            foreach (var p in productList)
            {
                var itemName = p.Name;
               (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems.Add(itemName, null, SelectedPreset);
                }
        }
        private void DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var parent = (ToolStripMenuItem)sender;
            int index = parent.DropDownItems.IndexOf(e.ClickedItem);
            Debug.WriteLine(index);
        }
