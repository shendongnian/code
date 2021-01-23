    public MainPage()
    {
       InitializeComponent();
       myPivot.IsHitTestVisible = false; // disable your Pivot
       Touch.FrameReported += Touch_FrameReported;
       TouchPanel.EnabledGestures = GestureType.HorizontalDrag; 
    }
    TouchPoint first;
    private void Touch_FrameReported(object sender, TouchFrameEventArgs e)
    {
        TouchPoint mainTouch = e.GetPrimaryTouchPoint(this);
        if (mainTouch.Action == TouchAction.Down)
            first = mainTouch;
        else if (mainTouch.Action == TouchAction.Up && TouchPanel.IsGestureAvailable)
        {
            if (mainTouch.Position.X < first.Position.X)
            {
                if (myPivot.SelectedIndex < myPivot.Items.Count - 1)
                    myPivot.SelectedIndex++;
            }
            else if (mainTouch.Position.X > first.Position.X)
            {
                if (myPivot.SelectedIndex > 0)
                    myPivot.SelectedIndex--;
            }
        }
    }
