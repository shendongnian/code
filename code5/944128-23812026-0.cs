    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        Rectangle clickedRectangle = FindClickedRectangle(e.Location);
        if (!clickedRectangle.IsEmpty)
            Console.WriteLine("X: {0} Y: {1}", clickedRectangle.X, clickedRectangle.Y);
    }
    private Rectangle FindClickedRectangle(Point point)
    {
        // Calculate the x and y indices in the grid the user clicked
        int x = point.X / 50;
        int y = point.Y / 50;
        // Check if the x and y indices are valid
        if (x < recArray.GetLength(0) && y < recArray.GetLength(1))
            return recArray[x, y];
            
        return Rectangle.Empty;
    }
