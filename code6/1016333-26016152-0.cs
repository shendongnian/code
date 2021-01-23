    void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
         float emSize = e.Item.Font.Size;
         Font font = new Font(e.Item.Font.FontFamily, emSize);
         while(e.Graphics.MeasureString(e.Item.Text, e.Item.Font).Width>e.Item.Bounds.Width)
         {
              emSize--;
              font = new Font(e.Item.Font.FontFamily, emSize);
              e.Item.Font = font;
         }
         e.DrawText();
    }
