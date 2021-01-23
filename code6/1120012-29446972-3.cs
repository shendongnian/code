        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                this.Exit();
            }
 
            if (_videoThread != null &&
                !_videoThread.IsAlive)
            {
                _videoThread = new Thread(DoVideoThread) { IsBackground = true, Name = "VideoThread" };
                _videoThread.Start();
            }
           // Get the current video frame as a texture for this frame
           if (_videoPlayer.State != MediaState.Stopped)
           {
               _videoTexture = _videoPlayer.GetTexture();
           }
            base.Update(gameTime);
        }
