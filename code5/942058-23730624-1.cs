        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Close the linked form, if it isn't disposed
            if (!((Form)((ToolStripItem)e.ClickedItem).Tag).IsDisposed)
            {
                ((Form)((ToolStripItem)e.ClickedItem).Tag).Close();
            }
            // Remove this menuitem from the menu
            contextMenuStrip1.Items.Remove((ToolStripItem)e.ClickedItem);
        }
