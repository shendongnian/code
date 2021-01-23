    void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
	if ((bool)e.NewValue == true)
	{
            Dispatcher.BeginInvoke(
	    DispatcherPriority.ContextIdle,
	    new Action(delegate()
	    {
		firstName.Focus();
	    }));
	} 
    }  
