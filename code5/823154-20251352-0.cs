    switch (e.KeyData)
    {
        case Keys.Right:
            button1.Location = new Point(button1.Left + 1, button1.Top);
            break;
        case Keys.Left:
            button1.Location = new Point(button1.Left - 1, button1.Top);
            break;
        case Keys.Up:
            button1.Location = new Point(button1.Left, button1.Top - 1);
            break;
        case Keys.Down:
            button1.Location = new Point(button1.Left, button1.Top + 1);
            break;
    }
