    CommandBar contextMenu = Globals.ThisAddIn.Application.CommandBars["Cell"];
    foreach (CommandBarControl control in contextMenu.Controls)
    {
        if (control.Caption == "item caption") // Specify here caption of your context menu item
        {
            contextMenuItem = (CommandBarButton)control;
            contextMenuItem.Enabled = true; // Specify here desired value for Enabled state to be set
        }
    }
