    private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        if (e.ClickedItem.Text == "Upload")
        {
            var contextMenu = sender as ContextMenuStrip;
            var yourControl = contextMenu.SourceControl as TypeOfYourControl;
            AllFiles = System.IO.Directory.GetFiles(yourControl.SelectedDirectory, "*.*", System.IO.SearchOption.AllDirectories);
            Bgw.RunWorkerAsync();
        }
    }
