    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawBackground();
        ImageList iList = listView1.LargeImageList;
        Size iSize = iList.ImageSize;
        int fSize2 = 7;
        Rectangle R0 = new Rectangle(Point.Empty, iSize);
        Rectangle R1 = new Rectangle(new Point(e.Bounds.X , e.Bounds.Y ),
                        new Size(iSize.Width - fSize2, iSize.Height - fSize2) );
        e.Graphics.DrawImage(iList.Images[e.Item.ImageIndex], R1, R0, GraphicsUnit.Pixel);
        e.Graphics.DrawString(e.Item.Text, Font, Brushes.Black, 
                              2f, e.Bounds.Y + iSize.Height - fSize2);
    }
