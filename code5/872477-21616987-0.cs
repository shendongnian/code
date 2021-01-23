    // this starts animation 
    System.Drawing.ImageAnimator.Animate(pictBox.Image, OnFrameChanged);
    
    // this stops animation
    System.Drawing.ImageAnimator.StopAnimate(pictBox.Image, OnFrameChanged);
    
    private void OnFrameChanged(object sender, EventArgs e)
    {
       // conditions
    }
