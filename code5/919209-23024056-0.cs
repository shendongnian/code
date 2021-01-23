    class MyGame : GameWindow
    {
        double seconds;
        Vector3 position;
    
        protected override void OnUpdateFrame(object sender, FrameEventArgs e)
        {
            // e.Time is the elapsed time from the previous UpdateFrame event
            // in seconds
            seconds += e.Time;
            position = new Vector3(
                (float)Math.Cos(seconds),
                (float)Math.Sin(seconds),
                1.0f);
        }
    }
