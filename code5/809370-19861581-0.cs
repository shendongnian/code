    using System.Drawing;
    
    const string MENU_TEXT_INDENT = "           ";
    
    private void MenuItemWithImage_Paint(Object sender, PaintEventArgs e) {
        ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
        if (!menuItem.Text.StartsWith(MENU_TEXT_INDENT)) {
            menuItem.Text = menuItem.Text.Insert(0, MENU_TEXT_INDENT);
        }
        Image img = menuItem.Image;
        e.Graphics.DrawImage(img, new Point(0, 0));
        menuItem.Refresh(); // May be needed to reflect changes - try without though!
    }
