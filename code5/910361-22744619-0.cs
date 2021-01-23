    private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
    {
        if (Debugger.IsAttached)
        {
            MessageBox.Show(e.ExceptionObject.Message + "\r\n" + e.ExceptionObject.StackTrace, "Error", MessageBoxButton.OK);
    
        }
    }
