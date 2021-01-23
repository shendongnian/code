    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (panel1.Bounds.Contains(this.PointToClient(Cursor.Position)))
        switch (keyData)
        {
            case Keys.PageDown: { scroll(10);  return true; }
            case Keys.PageUp:   { scroll(-10); return true; }
           // maybe code for some more keys..?
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
    void scroll(int delta)
    {
        panel1.AutoScrollPosition =  new Point(
               panel1.AutoScrollPosition.X, Math.Abs(panel1.AutoScrollPosition.Y) + delta);
    }
