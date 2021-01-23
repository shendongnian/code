    // message box flag.
    bool canIShowMessageBox = true;
    // for thread lock.
    object exLocker = new object();    
    void cc(object sender, UnhandledExceptionEventArgs e)
    {
       lock(exLocker)
       {
          if (canIShowMessageBox)
             canIShowMessageBox = false;
          else
             return;
       }
       Exception ex = e.ExceptionObject as Exception;
       MessageBox.Show(ex.Message, "Uncaught", MessageBoxButton.OK);
       lock(exLocker)
          canIShowMessageBox = true;
    }
