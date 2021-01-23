    listView1.OwnerDraw = true;
    listView1.DrawColumnHeader += listView1_DrawColumnHeader;
    listView1.DrawSubItem += listView1_DrawSubItem;
    void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
      e.DrawDefault = true;
    }
    void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
      if (e.ColumnIndex == 1) {
        e.Graphics.SetClip(e.Bounds);
        using (SolidBrush br = new SolidBrush(listView1.BackColor)) {
          e.Graphics.FillRectangle(br, e.Bounds);
        }
        int textLeft = e.Bounds.Left;
        string[] subItems = e.Item.SubItems[1].Text.Split(' ');
        for (int i = 0; i < subItems.Length; ++i) {
          int textWidth = TextRenderer.MeasureText(subItems[i], listView1.Font).Width;
          TextRenderer.DrawText(e.Graphics, subItems[i], listView1.Font,
              new Rectangle(textLeft, e.Bounds.Top, textWidth, e.Bounds.Height),
              i == 0 ? Color.Red : i == subItems.Length - 1 ? Color.Green : Color.Black, 
              Color.Empty,
              TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping);
          textLeft += textWidth;
        }
        e.Graphics.ResetClip();
      } else {
        e.DrawDefault = true;
      }
    }
