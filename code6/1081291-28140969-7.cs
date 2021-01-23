    AutoResetEvent autoEvent = new AutoResetEvent(true);
    
    System.Threading.Timer dt;
    private void toggle_MouseEnter(object sender, MouseEventArgs e)
    {
    	dt = new System.Threading.Timer(new TimerCallback(MoveFunct), autoEvent, 0, 1);
    }
    
    private void MoveFunct(Object stateInfo)
    {
    	Deployment.Current.Dispatcher.BeginInvoke(() => { verticalTransform.Y += 3; });
    }
    
    private void toggle_MouseLeave(object sender, MouseEventArgs e)
    {
    	dt.Dispose();
    }
