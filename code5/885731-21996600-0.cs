    private void tabControl1_MouseClick(object sender, MouseEventArgs e)
    {
        var zz = ((MouseEventArgs)e).Button;
        if (zz == MouseButtons.Right)
        {
            Point pt = tabControl1.PointToScreen(e.Location);
            tabContxt.Show(pt);
        }
    }
