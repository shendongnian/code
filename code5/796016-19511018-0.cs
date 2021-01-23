    /// <summary>
    /// Shows a popover.
    /// </summary>
    /// <param name='controllerToShow'>the controller to show in the popover</param>
    /// <param name='showFromRect'>the rectangle to present the popover from. Not used if showFromItem is specified.</param>
    /// <param name='showInView'>the view the popover is hosted in</param>
    /// <param name='showFromItem'>the bar button item the popover gets presented from.</param>
    /// <param name='popoverContentSize'>the content size of the popover</param>
    /// <param name='animated'>If set to <c>true</c>, animated the popover</param>
    /// <param name='arrowDirection'>the allowed arrow directions</param>
    /// <param name='onDismiss'>callback if the popover gets dismissed. Careful that the object that owns the callback doesn't outlive the popover controller to prevent uncollectable memory.</param>
    public static void ShowPopover(UIViewController controllerToShow, RectangleF showFromRect, UIView showInView, UIBarButtonItem showFromItem, SizeF popoverContentSize, bool animated = true, UIPopoverArrowDirection arrowDirection = UIPopoverArrowDirection.Any, EventHandler onDismiss = null)
    {
    	if(AppDelegateBase.popoverController != null)
    	{
    		AppDelegateBase.DismissPopover(false);
    	}
    
    	if(showFromItem == null && showFromRect.IsEmpty)
    	{
    		// Nothing to attach the popover to.
    		return;
    	}
    
    	popoverController = new UIPopoverController(controllerToShow);
    	if(!popoverContentSize.IsEmpty)
    	{
    		popoverController.SetPopoverContentSize(popoverContentSize, false);
    	}
    
    	if(onDismiss != null)
    	{
    		popoverController.DidDismiss += onDismiss;
    	}
    
    	// Send a notification that a popover will be presented.
    	NSNotificationCenter.DefaultCenter.PostNotificationName("WillPresentPopover", popoverController);
    
    	if(showFromItem != null)
    	{
    		popoverController.PresentFromBarButtonItem(showFromItem, arrowDirection, animated);
    	}
    	else 
    	{
    		popoverController.PresentFromRect(showFromRect, showInView, arrowDirection, animated );
    	}
    }
    
    /// <summary>
    /// Dismisses the popover presented using ShowPopover().
    /// </summary>
    /// <param name='animated'>If set to <c>true</c>, animates the dismissal</param>
    public static void DismissPopover(bool animated = false)
    {
    	if(popoverController != null)
    	{
    		popoverController.Dismiss(animated);
    	}
    	AppDelegateBase.popoverController = null;
    }
    private static UIPopoverController popoverController;
