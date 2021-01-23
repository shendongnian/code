        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                this.Exit();
 
                _videoThread = new Thread(DoVideoThread) { IsBackground = true, Name = "VideoThread" };
                _videoThread.Start();
                _videoThread.Join();
 
            base.Update(gameTime);
        }
