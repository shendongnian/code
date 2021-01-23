    fpsm = new FpsMonitor(); // in constructor
    fpsm.Update();// in update I think first line
    spriteBatch.Begin();  // in draw Last lines probably even after base.Draw(gameTime);
    fpsm.Draw(spriteBatch, fonts, new Vector2(5,5), Color.Red);
    spriteBatch.End();
