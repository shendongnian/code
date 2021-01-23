    public System.Windows.Threading.DispatcherTimer _timer = new System.Windows.Threading.DispatcherTimer();        
    
    _timer.Tick += _timer_Tick;
    _timer.Interval = new TimeSpan(0,0,1);
    _timer.Start();
    int second = 0;  // a local variable to keep tab on alternate visibility of elements per second in _timer_Tick
 
    void _timer_Tick(object sender, EventArgs e)
    {
      second++;
      if((second % 2) == 0) 
      {
        InnerContent.Visibility = System.Windows.Visibility.Hidden;
        BImage.Visibility = System.Windows.Visibility.Visible;
      }
      else
      {
        BImage.Visibility = System.Windows.VisibilityHidden;
        InnerContent.Visibilty = System.Windows.Visibility.Visible;
      }
    }
