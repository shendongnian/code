    void ShowCallback(object sender, UIKit.UIKeyboardEventArgs args)
    		{
    			// This happens if the user focuses a textfield outside of the
    			// tableview when the tableview is empty.
    
    			UIView activeView = new UIView();
    			// Find what opened the keyboard
    			foreach (UIView view in this.View.Subviews)
    			{
    				if (view.IsFirstResponder)
    				{
    					activeView = view;
    					break;
    				}
    			}
    
    			// Get the size of the keyboard
    			var keyboardBounds = args.FrameEnd;
    
    			// Create an inset and assign it to the tableview
    
    			//need to subtract the navbar at the bottom of the scree
    			nfloat toolbarHeight = 0f;
    			if (!this.NavigationController.ToolbarHidden)
    			{
    				toolbarHeight = this.NavigationController.Toolbar.Frame.Height;
    			}
    
    			nfloat adjustedInset = keyboardBounds.Size.Height - toolbarHeight;
    
    			UIEdgeInsets contentInsets = new UIEdgeInsets(0.0f, 0.0f, adjustedInset, 0.0f);
    			ExerciseTableView.ContentInset = contentInsets;
    			ExerciseTableView.ScrollIndicatorInsets = contentInsets;
    
    			// Make sure the tapped location is visible.
    			ExerciseTableView.ScrollRectToVisible(activeView.Frame, true);
    		}
