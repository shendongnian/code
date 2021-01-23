    private void Application_Startup(object sender, StartupEventArgs e)
    {
        this.RootVisual = new MainPage();
    
        var paramvalues = e.InitParams;
        foreach (var item in paramvalues)
        {
            MessageBox.Show(item.Value);    
        }
    }
