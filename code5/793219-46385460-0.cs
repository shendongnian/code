    public Form() {
        InitializeComponent();
        hScrollBar.Maximum = pictureBox.Width;
        hScrollBar.LargeChange = panel.Width; // panel which contain pictureBox, and this hScrollBar will same as panel scrollbar
        hScrollBar.Scroll += HScrollBar_Scroll;
    }
    private void HScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
        int diference = e.OldValue - e.NewValue;
        foreach (Control c in panel.Controls)
        {
             c.Location = new Point(c.Location.X + diference, c.Location.Y);
        }
    }
