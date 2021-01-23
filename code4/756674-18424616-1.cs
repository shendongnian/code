    //global variable
    bool isDragging = false;
    
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
                isDragging = true;               
    }
    
    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
                isDragging = false;               
    }
    
    private void form_Paint(object sender, EventArgs e)
    {
                if(isDragging)
                {
                   Point point = panel1.PointToClient(Cursor.Position);
                   Point cordinatedClikedPoint = new Point(xPanelPosition, yPanelPositon);
                   DrawPoint((point.X), (point.Y), Color.Navy);
                }
    }
