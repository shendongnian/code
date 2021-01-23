    private void genericView_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            rowX = e.X;
            rowY = e.Y;
        }
    }
