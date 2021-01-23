    public App()
    {
        Startup += App_Startup;        
    }
    
    void App_Startup(object sender, StartupEventArgs e)
    {
        TestApp.MainWindow.Instance.Show();
    }
