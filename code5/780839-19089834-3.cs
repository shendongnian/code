    ContextMenu = new ContextMenu(new []{new MenuItem("foo"), new MenuItem("bar")});
    foreach (MenuItem item in ContextMenu.MenuItems)
    {
        item.OwnerDraw = true;
        item.MeasureItem += item_MeasureItem;
        item.DrawItem += item_DrawItem;
    }
