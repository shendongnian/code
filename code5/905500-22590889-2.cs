    public class Player_Movement //This class deals with all movement relating to the player ie sprinting 
    {
        public Vector2 position, velocity, velocity_base, sprint;
        public Player_Main pmain = null;
        Game1 gamecore = new Game1();
    
        public Player_Movement(Player_Main pmain)
        {
            this.pmain = pmain;
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState KS = Keyboard.GetState();
            //Player movement using arrow keys
            if (KS.IsKeyDown(Keys.Up))
                position.Y -= velocity.Y;
            if (KS.IsKeyDown(Keys.Down))
                position.Y += velocity.Y;
            if (KS.IsKeyDown(Keys.Right))
                position.X += velocity.X;
            if (KS.IsKeyDown(Keys.Left))
                position.X -= velocity.X;
    
            //Making edge of screen stop player movement to prevent going off-screen
            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
            if (position.X + pmain.psprite.player.Width > gamecore.GraphicsDevice.Viewport.Width)
                position.X = gamecore.GraphicsDevice.Viewport.Width - pmain.psprite.player.Width;
            if (position.Y + pmain.psprite.player.Height > gamecore.GraphicsDevice.Viewport.Height)
                position.Y = gamecore.GraphicsDevice.Viewport.Height - pmain.psprite.player.Height;
            //
    
    
            //SPRINTING
            if (KS.IsKeyDown(pmain.pcontrols.sprintKey))
            {
                if (KS.IsKeyDown(Keys.Up) || KS.IsKeyDown(Keys.Down) || KS.IsKeyDown(Keys.Right) || KS.IsKeyDown(Keys.Left)) //You're only sprinting when you're moving, right?
                {
                    if (pmain.pstats.currentStamina > 0) //Only when you have stamina can you run
                    {
                        velocity.X += sprint.X;
                        velocity.Y += sprint.X;
                        pmain.pstats.currentStamina -= pmain.pstats.stamina; //Decreases stamina
                    }
                }
            }
            //
            //
            //SPRINTING
    
            if (pmain.pstats.currentStamina > 0)
            {
                if (velocity.X > velocity_base.X) //When current velocity becomes greater than base velocity check whether space bar is released
                {
                    if (KS.IsKeyUp(pmain.pcontrols.sprintKey))
                        velocity.X = velocity_base.X; //If it is, set current velocity back to base
                }
    
                if (velocity.Y > velocity_base.Y)
                {
                    if (KS.IsKeyUp(pmain.pcontrols.sprintKey))
                        velocity.Y = velocity_base.Y;
                }
    
                if (velocity.X > velocity_base.X + sprint.X)
                    velocity.X = velocity_base.X + sprint.X;
    
                if (velocity.Y > velocity_base.Y + sprint.Y)
                    velocity.Y = velocity_base.Y + sprint.Y;
                //
            }
    
            if (pmain.pstats.currentStamina <= 0) //When you run out of stamina, set speed to normal
            {
                velocity.X = velocity_base.X;
                velocity.Y = velocity_base.Y;
                pmain.pstats.currentStamina = 0;
            }
    
        }
        public void LoadContent(ContentManager Content)
        {
            position = new Vector2(400, 300);
            velocity = new Vector2(4, 4); //Current velocity
            velocity_base = new Vector2(4, 4); //Base velocity
            sprint = new Vector2(6, 6); //Added velocity when sprinting
        }
        public void Draw(SpriteBatch spriteBatch)
        {
    
        }
    }
