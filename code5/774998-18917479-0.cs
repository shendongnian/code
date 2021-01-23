    private int activeButton = -1;
    private void tabControl1_MouseMove(object sender, MouseEventArgs e)
    {
        int button;
        for (button = this.tabControl1.TabPages.Count-1; button >= 0; button--)
        {
            Rectangle r = tabControl1.GetTabRect(i);
            Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 12, 12);
            if (closeButton.Contains(e.Location)) break;
        }
        if (button != activeButton) {
            activeButton = button;
            tabControl1.Invalidate();
        }
    }
