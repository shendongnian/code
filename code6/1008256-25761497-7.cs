    public Form1()
    {
        InitializeComponent();
        listView1.Width = panel2.ClientSize.Width;
        listView1.Columns[0].Width = listView1.ClientSize.Width;
        listView1.Paint += listView1_Paint;
        listView1.BackColor = panel2.BackColor;
        leftBrush = new SolidBrush(panel2.BackColor);
        rightBrush = new SolidBrush(panel1.BackColor);
    }
    Pen borderPen = new Pen(SystemColors.ActiveBorder);
    SolidBrush leftBrush, rightBrush;
    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        if (e.ItemIndex == 0)  listView1_Paint(
            null, new PaintEventArgs(e.Graphics, listView1.ClientRectangle)); 
 
        if (!e.Item.Selected)
        {
          e.Graphics.FillRectangle(leftBrush, e.Bounds);
          e.Graphics.DrawLine(borderPen, 
                     listView1.Width-1, e.Bounds.Y, listView1.Width-1, e.Bounds.Bottom);
        }
        else
        {
           e.Graphics.FillRectangle(rightBrush , e.Bounds);
           e.Graphics.DrawLine(borderPen, 0, e.Bounds.Top, e.Bounds.Width, e.Bounds.Top);
           e.Graphics.DrawLine(borderPen, 
                               0, e.Bounds.Bottom-1, e.Bounds.Width, e.Bounds.Bottom-1);
        }
        e.Graphics.DrawString( e.Item.Text, listView1.Font, 
                              Brushes.Black, 35, e.Bounds.Y + 5 );
        e.Graphics.DrawImage(imageList1.Images[e.Item.ImageIndex], 2, e.Bounds.Y );
    }
    void listView1_Paint(object sender, PaintEventArgs e)
    {
        int hh = listView1.Items.Count * imageList1.ImageSize.Height;
        e.Graphics.DrawLine(borderPen, 
                   listView1.Width - 1, hh, listView1.Width - 1, listView1.Height);
    }
    private void panel2_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawLine(borderPen, panel2.Width-1, 0, panel2.Width-1, listView1.Top);
    }
