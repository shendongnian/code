    I modified it a bit, then its working fine, please do try like this below
    
    protected override void Update(GameTime gameTime) {
            if (_videoThread == null &&
                           _videoPlayer.State == MediaState.Stopped)
            {
                _videoThread = new Thread(DoVideoThread) { IsBackground = true, Name = "VideoThread" };
                _videoThread.Start();
            }
    }// modified draw
     protected override void Draw(GameTime gameTime)
        {         if (_videoThread != null &&    !_videoThread.IsAlive && _videoPlayer.State == MediaState.Stopped)
            {   _videoThread = new Thread(DoVideoThread) { IsBackground = true, Name = "VideoThread" };
                _videoThread.Start();}
            // Draw the video, if we have a texture to draw.
            if (_videoTexture != null)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(_videoTexture, screen, Color.White);
                spriteBatch.End();
            }
    
            base.Draw(gameTime);
        }
      }
    }
    
    Thanks
