    private void tabControl1_DrawItem_1(object sender, DrawItemEventArgs e)
    {
        if (e.Index == tabControl1.SelectedIndex)
        {
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text,
                new Font(tabControl1.Font, FontStyle.Bold),
                Brushes.Aqua,
                new PointF(e.Bounds.X + 3, e.Bounds.Y + 3));
        }
        else
        {
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text,
                tabControl1.Font,
                Brushes.Black,
                new PointF(e.Bounds.X + 3, e.Bounds.Y + 3));
        }
    }
