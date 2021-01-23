    public void MainWindow_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Exception exception = (Exception)e.ExceptionObject;
        if (exception.TargetSite.Module.ToString() == "nameOfViewModelAssembly.dll")
        {
            if (exception.StackTrace.Contains(nameOfSomeViewModel))
            {
                throw new Exception("Problem in nameOfSomeViewModel", exception);
            }
            else if (exception.StackTrace.Contains(nameOfOtherViewModel))
            {
                throw new Exception("Problem in nameOfOtherViewModel", exception);
            }
        }
    }
