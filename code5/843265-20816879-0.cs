    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        float DragVelocity, DragDistance, DragTime;
        TimeSpan time;
        Vector2 StartPoint, EndPoint;
        bool isThisFirstTime = true;
    
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            TargetElapsedTime = TimeSpan.FromTicks(333333);
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }
    
        protected override void Initialize()
        {
            base.Initialize();
        }
    
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TouchPanel.EnabledGestures = GestureType.DragComplete | GestureType.FreeDrag;
        }
    
        protected override void Update(GameTime gameTime)
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gs = TouchPanel.ReadGesture();
                switch (gs.GestureType)
                {
                    case GestureType.FreeDrag:
                        if (isThisFirstTime == true)
                        {
                            time = TimeSpan.Zero;
                            StartPoint = gs.Position;
                            isThisFirstTime = false;
                        }
                        else
                        {
                            EndPoint = gs.Position;
                            time += gameTime.ElapsedGameTime;
                        }
                        break;
    
                    case GestureType.DragComplete:
                        isThisFirstTime = true;
                        DragTime = (float) time.TotalSeconds;
                        DragDistance = Vector2.Distance(StartPoint, EndPoint);
                        DragVelocity = DragDistance / DragTime;
                        break;
                }
            }
            base.Update(gameTime);
        }
    
    
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
