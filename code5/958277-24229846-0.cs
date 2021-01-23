    `private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        int imagewidth = 50;
        Rectangle R = new Rectangle(e.Bounds.Left, e.Bounds.Top, 
                      listView1.ClientRectangle.Width, e.Bounds.Height);
        if (e.Item.Focused) e.Graphics.FillRectangle(Brushes.LightBlue, R);
        else if (e.ItemIndex % 2 == 1) e.Graphics.FillRectangle(Brushes.GhostWhite, R);
        e.Graphics.DrawImage(imageList1.Images[e.Item.ImageIndex],
                             e.Bounds.Left, e.Bounds.Top);
        e.Graphics.DrawString(e.Item.Text, 
                              new Font(listView1.Font.FontFamily, 11f, FontStyle.Bold), 
                              Brushes.Black, imagewidth, e.Bounds.Top + 3);
        e.Graphics.DrawString(e.Item.SubItems[1].Text, 
                              new Font(listView1.Font.FontFamily, 10f), 
                              Brushes.Black, imagewidth, e.Bounds.Top + 15);
    }`
