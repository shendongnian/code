    MediaTimeline timeline = new MediaTimeline(new Uri(@path, UriKind.Relative));
    MediaClock clock = timeline.CreateClock(true) as MediaClock; //make the clock controllable
    MediaPlayer player = new MediaPlayer();
    player.Clock = clock;
    VideoDrawing drawing = new VideoDrawing();
    drawing.Rect = new Rect(0, 0, 300, 200);
    drawing.Player = player;
    DrawingBrush brush = new DrawingBrush(drawing);
    New_WEBMPlayer_Wnd.Background = brush;
    //stop the clock when player window is closed
    New_WEBMPlayer_Wnd.Closed += (s, e) =>
    {
        if (clock.CurrentState != ClockState.Stopped)
        {
            clock.Controller.Stop();
        }
    };
