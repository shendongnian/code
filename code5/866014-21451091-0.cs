    this.MouseMove += TestForm_MouseMove;
    
    private Point mousePosition;
    void TestForm_MouseMove(object sender, MouseEventArgs e)
    {
        this.mousePosition = e.Location;
    }
