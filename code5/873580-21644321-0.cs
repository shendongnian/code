    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
    	base.OnNavigatedTo(e);
    	var newsTitle = "";
    	//check if particular parameter available in uri string
    	if (this.NavigationContext.QueryString.ContainsKey("News_Title"))
    	{
    		//if it is available, get parameter value
    		newsTitle = NavigationContext.QueryString["News_Title"];
    	}
    }
