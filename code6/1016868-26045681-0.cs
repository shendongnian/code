    var titleName = "TITLE";
    
    var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
    statusBar.ProgressIndicator.Text = titleName;
    var applicationView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
    applicationView.Title = titleName;
  
  
