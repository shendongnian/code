    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.X >= button.Location.X && e.X < button.Location.X + button.Width
            && e.Y >= button.Location.Y && e.Y <= button.Location.Y + button.Height)
        {
            if (!isShown)
            {
                tt.Show("MyToolTip", button, button.Width / 2, button.Height / 2);
                isShown = true;
            }
                
        }
        else
        {
            tt.Hide(button);
            isShown = false;
        }
    }
