    private Point location = Point.Empty;
    private Image newImage;
    private void OnTimerTick(object sender, EventArgs e)
    {
        location.Offset(1,1);
        this.Invalidate();
    }
    
    public void DrawImagePoint(PaintEventArgs e)
    {
        if(newImage == null)
        {
            newImage = A_Worm_Nightmare.Properties.Resources.Worm;    
        }
        e.Graphics.DrawImage(newImage, location);
    }
