    protected override void RightClickMenu()
    {
        this.rightClickContextMenu = new ContextMenu();
        this.rightClickContextMenu.MenuItems.Add("MY CLASSES", new System.EventHandler(myclasses_Click));
        this.rightClickContextMenu.MenuItems.Add("MY BOOK LISTS", new System.EventHandler(booklists_Click));
        this.gridView.PopupMenuShowing += gridView_PopupMenuShowing;
        this.gridView.MouseDown += gridView_MouseDown;
    }
    private void gridView_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right)
            return;
        var hitInfo = this.gridView.CalcHitInfo(e.Location);
        if (!hitInfo.InColumn)
            this.gridView.GridControl.ContextMenu = this.rightClickContextMenu;
        else
            this.gridView.GridControl.ContextMenu = null;
    }
