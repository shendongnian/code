    private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right )
        {
           DoRightClickStuff();
        }
        else if (e.Button == System.Windows.Forms.MouseButtons.Left )
        {
            DoLeftClickStuff();
        }
     }
