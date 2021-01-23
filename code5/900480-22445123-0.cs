    int timer = 0;
    Rectangle position = new Rectangle(100, 100, 80, 80); // position 100x, 100y, and size is 80 width and height.
    Rectangle source = new Rectangle(0, 0, 80, 80); // Position on the spritesheet is 0, 0 which should be first frame, and the frames are all 80*80 pixels in size.
    private void OnUpdate(object sender, GameTimerEventArgs e)
    {
        timer += e.ElapsedTime.TotalMilliseconds;
        if(timer > 30) // If it has been 0.03 seconds = 33 frames per second
        {
            timer = 0; // reset timer
            source.X += 80; // Move x value to next frame
            if(source.X > widthOfYourSpriteSheet) source.X = 0; // Reset the animation to the beginning when we are at the end
        }
    }
