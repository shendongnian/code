    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    
    namespace WalkingAnimation
    {
        public class Game1 : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
            private AnimatedSprite animatedSprite, animatedSprite2;
            private Vector2 position = new Vector2(350f, 200f);
            private KeyboardState keyState;
            private bool idle;
    
            public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
    
            protected override void Initialize()
            {
                base.Initialize();
                // Start of as idle
                idle = true;
            }
    
            protected override void LoadContent()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
                // Textures
                Texture2D texture = Content.Load<Texture2D>("Idle");
                Texture2D texture2 = Content.Load<Texture2D>("Run");
                // Animations
                animatedSprite = new AnimatedSprite(texture, 1, 11);
                animatedSprite2 = new AnimatedSprite(texture2, 1, 10);
            }
    
            protected override void UnloadContent()
            {
            }
    
            protected override void Update(GameTime gameTime)
            {
                keyState = Keyboard.GetState();
                idle = true; // If the character doesn't move this will stay true
   
                if (keyState.IsKeyDown(Keys.Q))
                {
                    position.X -= 3;
                    idle = false;
                }
                if (keyState.IsKeyDown(Keys.P))
                {
                    position.X += 3;
                    idle = false;
                }
    
                base.Update(gameTime);
                animatedSprite.Update();
                animatedSprite2.Update();
            }
    
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
    
                base.Draw(gameTime);
                if(idle)
                    animatedSprite.Draw(spriteBatch, position);
                else
                    animatedSprite2.Draw(spriteBatch, position);
            }
        }
    }
