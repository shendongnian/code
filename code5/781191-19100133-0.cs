    private void MyControl_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            MyControl.Left = e.X + MyControl.Left - MouseDownLocation.X;
            MyControl.Top = e.Y + MyControl.Top - MouseDownLocation.Y;
        }
    }
