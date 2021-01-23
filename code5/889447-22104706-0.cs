    private void Form1_Activated(object sender, EventArgs e)
    {
        for (int i = 0; i < toolStrip1.Items.Count; i++)
        {
            ToolStripItem c = toolStrip1.Items[i];
            if (new RectangleF(new Point(i * (c.Size.Width - 1) + this.Location.X + 18, this.Location.Y + 32), c.Size).Contains(MousePosition))
                c.PerformClick();
        }
    }
