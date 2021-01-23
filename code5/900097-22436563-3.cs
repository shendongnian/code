    public MainPage OtherWindow
    {
    	return (MainPage)(((System.Windows.Controls.ContentControl)(App.RootFrame)).Content);
    }
    
    //usage :
    OtherWindow.getMyPublicMethod();
