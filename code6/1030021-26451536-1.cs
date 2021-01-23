    void rotationTimer_Tick(object sender, EventArgs e)
    {
    	Image flipImage = pictureBox1.Image;
    	flipImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
    	pictureBox1.Image = flipImage;
    }
    
    private void pictureBox1_MouseEnter(object sender, EventArgs e)
    {
    	rotationTimer.Start();
    }
    
    private void pictureBox1_MouseLeave(object sender, EventArgs e)
    {
    	rotationTimer.Stop();
    }
