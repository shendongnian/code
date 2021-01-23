    var userControl = oldContent as Catel.Windows.Controls.UserControl;
    if (userControl != null)
    {
    	userControl.CloseViewModelOnUnloaded = false;
    }
    
    PreviousContentPresentationSite.Content = oldContent;
