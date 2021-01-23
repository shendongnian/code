    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (panel1.Bounds.Contains(this.PointToClient(Cursor.Position)))
        switch (keyData)
        {
            case Keys.PageDown:
                // left arrow key pressed
                scroll(10);
                return true;
            case Keys.PageUp:
                scroll(-10);
                // right arrow key pressed
                return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
    void scroll(int delta)
    {
        panel1.AutoScrollPosition =  new Point(
               panel1.AutoScrollPosition.X, Math.Abs(panel1.AutoScrollPosition.Y) + delta);
    }
