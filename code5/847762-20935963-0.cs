    // Add that field to your class.
    private readonly DispatcherTimer moveLeftTimer;
    // In the constructor, add the lines inside:
    YourClassName() // This line is a stub - I do not know your class name.
    {
        moveLeftTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(50)
        };
        moveLeftTimer.Tick += MoveLeft;
    }
    private void MoveLeft(object source, EventArgs e)
    {
        Character.Left -= XSpeed;
    }
    private void Character_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A)
        {
            moveLeftTimer.IsEnabled = true;
        }
    }
    private void Character_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A)
        {
            moveLeftTimer.IsEnabled = false;
        }
    }
