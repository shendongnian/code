    private readonly TextBox txt = new TextBox { BorderStyle = BorderStyle.FixedSingle, Visible = false };
    public Form1()
    {
        InitializeComponent();
        listView1.Controls.Add(txt);
        listView1.FullRowSelect = true;
        txt.Leave += (o, e) => txt.Visible = false;
    }
    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        ListViewHitTestInfo hit = listView1.HitTest(e.Location);
        Rectangle rowBounds = hit.SubItem.Bounds;
        Rectangle labelBounds = hit.Item.GetBounds(ItemBoundsPortion.Label);
        int leftMargin = labelBounds.Left - 1;
        txt.Bounds = new Rectangle(rowBounds.Left + leftMargin, rowBounds.Top, rowBounds.Width - leftMargin - 1, rowBounds.Height);
        txt.Text = hit.SubItem.Text;
        txt.SelectAll();
        txt.Visible = true;
        txt.Focus();
    }
