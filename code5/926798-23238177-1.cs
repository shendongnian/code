    private Point location = Point.Empty;
    private Image newImage;
    private void OnTimerTick(object sender, EventArgs e)
    {
        location.Offset(1,1);
        //Do flipping here
        newImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
        this.Invalidate();//Makes form to repaint
    }
    
    public void DrawImagePoint(PaintEventArgs e)
    {
        if(newImage == null)
        {
            newImage = A_Worm_Nightmare.Properties.Resources.Worm;    
        }
        e.Graphics.DrawImage(newImage, location);
    }
