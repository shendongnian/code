    public MainPage getMainPage()
    {
    	return (MainPage)(((System.Windows.Controls.ContentControl)(App.RootFrame)).Content);
    }
    
    //usage :
    getMainPage().getMyPublicMethod();
