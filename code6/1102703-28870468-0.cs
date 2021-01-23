    private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
    {
        if (e.MenuType != GridMenuType.Column)
            return;
    
        DXMenuItem menuItem = null;
    
        foreach (DXMenuItem item in e.Menu.Items)
            if (item.Tag.Equals(GridStringId.MenuColumnConditionalFormatting))
            {
                item.Visible = false;
    
                menuItem = ((DXSubMenuItem)item).Items[0];
    
                break;
            }
    
        menuItem.BeginGroup = true;
    
        if (menuItem != null)
            e.Menu.Items.Add(menuItem);
    }
