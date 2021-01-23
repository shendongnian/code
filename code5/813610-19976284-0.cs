    public System.Windows.Threading.DispatcherTimer _timer = new System.Windows.Threading.DispatcherTimer();        
    
    _timer.Tick += _timer_Tick;
    _timer.Interval = new TimeSpan(0,0,1);
    _timer.Start();
    int second = 0;
 
    void _timer_Tick(object sender, EventArgs e)
    {
      second++;
      if((second % 2) == 0) {
       BImage.Visibility = Visible;
      }
      else{
       InnerContent.Visibilty = Visible;
      }
    }
