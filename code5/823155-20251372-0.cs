    private void OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Right)
        {
            button1.Location = new Point(button1.Location.X + 1, button1.Location.Y);
        }
    }
