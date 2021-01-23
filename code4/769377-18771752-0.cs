    public class ObjectInfo
        {
            public Vector2 Position { get; set; }
            public Vector2 Speed { get; set; }
            public Vector2 Acceleration { get; set; }
        }
        private DispatcherTimer dispatcherTimer;
        private int refreshTimeMilisecond = 100;
        private ObjectInfo myObject;
        public void Init()
        {
            myObject = new ObjectInfo();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(refreshTimeMilisecond);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
        }
    void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            myObject.Position = myObject.Position + myObject.Speed*refreshTimeMilisecond;
            myObject.Speed = myObject.Speed + myObject.Acceleration * refreshTimeMilisecond;
            Canvas.SetTop(myControl, myObject.Position.X);
            Canvas.SetLeft(myControl, myObject.Position.Y);
        }
