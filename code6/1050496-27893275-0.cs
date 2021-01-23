    using ShakeGestures;  //Add the reference
    public MainPage()
    {
     InitializeComponent();
     ShakeGesturesHelper.Instance.ShakeGesture += Instance_ShakeGesture; 
     ShakeGesturesHelper.Instance.MinimumRequiredMovesForShake = 10;
     ShakeGesturesHelper.Instance.Active = true;
    }
    void Instance_ShakeGesture(object sender, ShakeGestureEventArgs e)
    {
     Deployment.Current.Dispatcher.BeginInvoke(() =>
     {
                
      //Perform the required tasks.
     });
    }
