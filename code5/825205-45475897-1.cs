    public YourClassConstructor()
    {
        this.tcRemontas.DrawMode = TabDrawMode.OwnerDrawFixed;
        this.tcRemontas.Appearance = TabAppearance.FlatButtons;
        tcRemontas.DrawItem += TcRemontas_DrawItem;
    }
    private void TcRemontas_DrawItem(object sender, DrawItemEventArgs e)
    {
        TabControl tabControl = sender as TabControl;
        if (e.Index == tabControl.SelectedIndex)
        {
            e.Graphics.DrawString(tabControl.TabPages[e.Index].Text,
                new Font(tabControl.Font, FontStyle.Bold),
                Brushes.Black,
                new PointF(e.Bounds.X + 3, e.Bounds.Y + 3));
        }
        else
        {
            e.Graphics.DrawString(tabControl.TabPages[e.Index].Text,
                tabControl.Font,
                Brushes.Black,
                new PointF(e.Bounds.X + 3, e.Bounds.Y + 3));
        }
    }
