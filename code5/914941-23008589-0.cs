    using System.Text;
       using Microsoft.Xna.Framework;
       using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    namespace  WindowsGame1
    {
     class Paddle
     {
     Vector2 position;
     Vector2 motion;
     float paddleSpeed = 8f;
     KeyboardState keyboardState;
     GamePadState gamePadState;
     Texture2D texture;
         Rectangle screenBounds;
     public Paddle(Texture2D texture, Rectangle screenBounds)
     {
     this.texture = texture;
     this.screenBounds = screenBounds;
     SetInStartPosition();
     }
     public void Update()
     {
     motion = Vector2.Zero;
     keyboardState = Keyboard.GetState();
     gamePadState = GamePad.GetState(PlayerIndex.One);
     if (keyboardState.IsKeyDown(Keys.Left))
     motion.X = -1;
     if (keyboardState.IsKeyDown(Keys.Right))
     motion.X = 1;
     if (gamePadState.ThumbSticks.Left.X < -.5f)
     motion.X = -1;
     if (gamePadState.ThumbSticks.Left.X > .5f)
     motion.X = 1;
     motion.X *= paddleSpeed;
     position += motion;
     LockPaddle();
     }
     private void LockPaddle()
     {
     if (position.X < 0)
     position.X = 0;
     if (position.X + texture.Width > screenBounds.Width)
     position.X = screenBounds.Width - texture.Width;
     }
     public void SetInStartPosition()
     {
     position.X = (screenBounds.Width - texture.Width) / 2;
     position.Y = screenBounds.Height - texture.Height - 5;
     }
     public void Draw(SpriteBatch spriteBatch)
     {
     spriteBatch.Draw(texture, position, Color.White);
     }
     public Rectangle GetBounds()
     {
     return new Rectangle(
     (int)position.X, 
     (int)position.Y, 
     texture.Width,
     texture.Height);
     }
     }
    }
