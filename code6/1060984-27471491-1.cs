    private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        if (e.ClickedItem.Text == "Upload")
        {
            var menuItem = sender as ToolStripItem;
            var contextMenu = menuItem.Parent as ContextMenuStrip;
            var yourControl = contextMenu.SourceControl as TypeOfYourControl;
            //Get information from your control and "do something"
        }
    }
