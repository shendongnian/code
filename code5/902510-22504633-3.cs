    var vmContainer = PreviousContentPresentationSite.Content as IViewModelContainer;
    if (vmContainer != null)
    {
    	vmContainer.PreventViewModelCreation = false;
    }
    
    AbortTransition();
