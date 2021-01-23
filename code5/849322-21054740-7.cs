    public MainPage()
    {
       InitializeComponent();
       TouchPanel.EnabledGestures = GestureType.Pinch;
       this.ManipulationCompleted+=MainPage_ManipulationCompleted;            
    }
    private void MainPage_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
    {
      if (TouchPanel.IsGestureAvailable)
      {
         GestureSample gesture = TouchPanel.ReadGesture();
         Vector2 vector = gesture.Position;
         int positionX = (int)vector.X;
         int positionY = (int)vector.Y; 
         // do what you want with your positin
         // there are also some more properties in which you may be interested
         // also TouchPanel has properites like TouchPanel.DisplayWidth and DisplayHeight if you need them
      }
    }
