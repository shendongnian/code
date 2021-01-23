    public MainPage()
    {
       InitializeComponent();
       TouchPanel.EnabledGestures = GestureType.Flick;
       myTextBlock.ManipulationCompleted += myTextBlock_ManipulationCompleted;
    }
    private void myTextBlock_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
    {
       if (TouchPanel.IsGestureAvailable)
       {
          GestureSample gesture = TouchPanel.ReadGesture();
          switch (gesture.GestureType)
          {
            case GestureType.Flick:
                if (e.FinalVelocities.LinearVelocity.X < 0)
                            // do for one side
                if (e.FinalVelocities.LinearVelocity.X > 0)
                            // do for second side
                break;
            default:
                break;
          }
      }
    }
