	this.Dispatcher.BeginInvoke(new Action(delegate
    {
		foreach(Visual item in ListOfVisuals)
		{
			WrapPAnel.Children.Add(item);
		}
	}), DispatcherPriority.Background);
