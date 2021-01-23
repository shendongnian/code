    public void mouseDown(object sender, MouseButtonEventArgs m)
    {
      Touch.FrameReported += OnTouchFrameReported;
    }
    public void mouseUp(object sender, MouseButtonEventArgs m)
    {
      Touch.FrameReported -= OnTouchFrameReported;
     }
 
