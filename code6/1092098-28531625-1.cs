    public Form1()
    {
        InitializeComponent();
        shadow = (Bitmap)Image.FromFile(aDropShadowBitmap);
        overlay = new Bitmap(64, 64);
        using (Graphics G = Graphics.FromImage(overlay))
                G.Clear(Color.FromArgb(127, 31, 191, 255));
    }
    Bitmap shadow;
    Bitmap overlay;
    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        ListViewItem item = e.Item;
        Point bLoc = new Point(e.Bounds.X + 35, e.Bounds.Y + 10);
        Size imgS = imageList1.ImageSize;
        e.Graphics.DrawImage(shadow, bLoc);
        e.Graphics.DrawImage(imageList1.Images[e.ItemIndex], bLoc);
        if ((e.State & ListViewItemStates.Selected) == ListViewItemStates.Selected)
        {
            e.Graphics.DrawImage(overlay, bLoc);
        }
        else  {  }
        e.Graphics.DrawString(item.Text, listView1.Font, Brushes.Black,
                    bLoc.X, bLoc.Y + imgS.Height + 10);
    }
