    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.X >= pnlOne.Location.X && e.X <= pnlOne.Location.X + pnlOne.Size.Width && pnlOne.Visible == false && e.Y >= pnlOne.Location.Y && e.Y <= pnlOne.Location.Y + pnlOne.Size.Height)
        {
            pnlOne.Visible = true;
            pnlOne.Enabled = true;
        }
    }
    private void pnlOne_MouseLeave(object sender, EventArgs e)
    {
        pnlOne.Visible = false ;
        pnlOne.Enabled = false ;
    }
