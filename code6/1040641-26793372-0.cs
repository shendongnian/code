    private Point mouseDown, buttonLocation;
    private bool isDragged = false;
    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragged = true;
            mouseDown = Cursor.Position;
            buttonLocation = button1.Location;
        }
            
    }
    private void button1_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragged)
        {
            button1.Location = new Point(buttonLocation.X + (Cursor.Position.X - mouseDown.X), button1.Location.Y);
        }
    }
    private void button1_MouseUp(object sender, MouseEventArgs e)
    {
        isDragged = false;
    }
