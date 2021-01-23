    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        if ( e.SubItem.Name != "click1") e.DrawDefault = true; 
        else
        {
            if (e.Item.Selected)
                  e.Graphics.FillRectangle(Brushes.SeaShell, 
                                           new Rectangle(e.Bounds.Location, e.Bounds.Size));
            else  e.Graphics.FillRectangle(Brushes.WhiteSmoke, 
                                           new Rectangle(e.Bounds.Location, e.Bounds.Size));
            e.DrawText();
        }
    }
    private void listView1_DrawColumnHeader(object sender, 
                                            DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawDefault = true;
    }
