    public AppWindow()
    {
        ((App)Application.Current).AppWindow = this;
    }
    
    class App : Application
    {
        public AppWindow AppWindow { get; set; }
    
        private void Application_DispatcherUnhandledException(object sender,
                                   DispatcherUnhandledExceptionEventArgs e)
        {
            //..... Processing Code
        
            NavigationService svc = NavigationService.GetNavigationService(AppWindow);
        
            svc.Navigate(new DIEM.WindowsApps.DIEMWindows.ErrorWindow());
        }
    
    }
