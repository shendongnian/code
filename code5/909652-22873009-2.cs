    public MainPage()
    {
        InitializeComponent();
        TouchPanel.EnabledGestures = GestureType.FreeDrag;
        Touch.FrameReported += Touch_FrameReported;
    }
    private void Touch_FrameReported(object sender, TouchFrameEventArgs e)
    {
        if (TouchPanel.IsGestureAvailable) // check only dragging 
        {
           // get point relative to Viewport
           TouchPoint mainTouch = e.GetPrimaryTouchPoint(ViewPortTestTest);
           // check if drag has completed (key up)
           if (mainTouch.Action == TouchAction.Up)
           {
              Temp.x = mainTouch.Position.X;
              Temp.y = mainTouch.Position.Y;
           }
        }
    }
