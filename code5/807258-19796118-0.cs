    private Image backBuffer = new Bitmap(2000, 2000);
    private Image frontBuffer = new Bitmap(2000, 2000);
    private Image clearSprite = new Bitmap(2000, 2000);
    
    // Draws 1 frame
    private void Draw()
    {
      // Clear the back buffer
      backBuffer.Draw(clearSprite);
      
      // Draw sprites
      foreach (var sprite in sprites)
      {
        backBuffer.Draw(sprite);
      }
      
      // Swap buffers
      frontBuffer.Draw(backBuffer);
    }
