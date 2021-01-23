    if (currentMouseOverRow >= 0)
    {
        m.MenuItems.Add(new MenuItem(string.Format("Row number {0}", currentMouseOverRow.ToString())));
        m.MenuItems[m.MenuItems.Count - 1].OwnerDraw = true;
        m.MenuItems[m.MenuItems.Count - 1].DrawItem += Cm_DrawItem;
        m.MenuItems[m.MenuItems.Count - 1].MeasureItem += MeasureMenuItem;
    }
    void MeasureMenuItem(object sender,MeasureItemEventArgs e)
    {
        MenuItem m = (MenuItem) sender;
        Font font = new Font(Font.FontFamily, Font.Size, Font.Style);
        SizeF sze = e.Graphics.MeasureString(m.Text, font);
        e.ItemHeight = (int)sze.Height;
        e.ItemWidth = (int)sze.Width;
    }
