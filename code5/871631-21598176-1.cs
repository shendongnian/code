    public MainPage()
    {
       InitializeComponent();
       Touch.FrameReported += Touch_FrameReported;
    }
    TouchPoint first;
    private void Touch_FrameReported(object sender, TouchFrameEventArgs e)
    {
       TouchPoint mainTouch = e.GetPrimaryTouchPoint(myWebBrowser);
       if (mainTouch.Action == TouchAction.Down)
             first = mainTouch;
       else if (mainTouch.Action == TouchAction.Up)
       {
           if (mainTouch.Position.X - first.Position.X < 0)
                MessageBox.Show("Next item.");
               //myPivot.SelectedIndex++;
           if (mainTouch.Position.X - first.Position.X > 0)
               MessageBox.Show("Previous item.");
              //myPivot.SelectedIndex--;
       }
    }
