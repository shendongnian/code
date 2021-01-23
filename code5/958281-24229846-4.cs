    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
     Point point0 = new Point(e.Bounds.Left, e.Bounds.Top);
     Point point1 = new Point(imageList1.ImageSize.Width + 10, e.Bounds.Top + 5);
     Point point2 = new Point(imageList1.ImageSize.Width + 10, e.Bounds.Top + 25);
     
     Size size = new Size(listView1.ClientRectangle.Width, e.Bounds.Height);
     Rectangle R = new Rectangle(point0, size);
     Font F1 = new Font(listView1.Font.FontFamily, 11f, FontStyle.Bold);
     Font F2 = new Font(listView1.Font.FontFamily, 10f);
     
     if (e.Item.Focused) e.Graphics.FillRectangle(Brushes.LightBlue, R);
      else if (e.ItemIndex % 2 == 1) e.Graphics.FillRectangle(Brushes.GhostWhite, R);
     e.Graphics.DrawImage(imageList1.Images[e.Item.ImageIndex], point0 );
     e.Graphics.DrawString(e.Item.Text, F1, Brushes.Black, point1);
     e.Graphics.DrawString(e.Item.SubItems[1].Text, F2, Brushes.Black, point2);
     
     F1.Dispose(); F2.Dispose();
    }
