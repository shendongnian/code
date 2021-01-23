    public class GameTimer: Microsoft.Xna.Framework.GameComponent
    {
        /// <summary>
        /// Used to keep track of how much time since the previous Tick.
        /// </summary>
        protected TimeSpan ElapsedTime { get; set; }
        /// <summary>
        /// Gets or sets the amount of time between timer ticks.
        /// </summary>
        public virtual TimeSpan Interval { get; set; }
        /// <summary>
        /// Gets or sets a value that indicates whether the timer is running.  
        /// </summary>
        public bool IsEnabled { get; set; }
        public GameTimer(Microsoft.Xna.Framework.Game game)
            : base(game)
        {
        }
        public GameTimer(Microsoft.Xna.Framework.Game game, TimeSpan interval)
            : this(game)
        {
            Interval = interval;
        }
        /// <summary>
        /// Starts the GameTimer.
        /// </summary>
        public void Start()
        {
            IsEnabled = true;
        }
        /// <summary>
        /// Stops the GameTimer.
        /// </summary>
        public void Stop()
        {
            // Disable the timer.
            IsEnabled = false;
            // Reset the elapsed time to 0.
            ElapsedTime = TimeSpan.Zero;
        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            bool ticked = false;
            // Figure out how many Ticks we need.
            if (IsEnabled && this.Interval > TimeSpan.Zero)
            {
                var args = new GameTimeEventArgs(gameTime);
                ElapsedTime = ElapsedTime.Add(gameTime.ElapsedGameTime);
                while (IsEnabled && ElapsedTime >= Interval)
                {
                    if (!ticked)
                    {
                        ticked = true;
                        OnTickFirst(args);
                    }
                    ElapsedTime = ElapsedTime.Subtract(Interval);
                    OnTick(args);
                }
                // If we know we ticked at least once during this Update, raise event that we're on the last Tick.
                if (ticked)
                {
                    OnTickLast(args);
                }
            }
            base.Update(gameTime);
        }
        public event EventHandler<GameTimeEventArgs> TickFirst;
        /// <summary>
        /// Event fired during Update for each tick defined by the interval set on the timer.  
        /// Depending on how quickly the update loop is running, this event may fire 0-N times during a single Update.
        /// </summary>
        public event EventHandler<GameTimeEventArgs> Tick;
        public event EventHandler<GameTimeEventArgs> TickLast;
        protected virtual void OnTickFirst(GameTimeEventArgs e)
        {
            if (TickFirst != null)
                TickFirst(this, e);
        }
        protected virtual void OnTick(GameTimeEventArgs e)
        {
            if (Tick != null)
                Tick(this, e);
        }
        protected virtual void OnTickLast(GameTimeEventArgs e)
        {
            if (TickLast != null)
                TickLast(this, e);
        }
    }
