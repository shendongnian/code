    Process.Start("http://www.google.com");
    IntPtr handle = new IntPtr();
    bool found = false;
    // Get handle of browser window ready to move / bring to front
    // Wait for browser process to start before moving on
    while (!found)
    {
      foreach (Process clsProcess in Process.GetProcesses())
      {
        Console.WriteLine(clsProcess.MainWindowTitle);
        if (clsProcess.MainWindowTitle.Contains("Google"))
        {
          found = true;
          handle = clsProcess.MainWindowHandle;
         }
        }        
         Thread.Sleep(500);
       }
    Console.WriteLine("Window Found");
    // This method gets the users preferred screen (not included in this code snippet)
    ConnectedScreen PreferredScreen = GetPreferredScreen(GetScreens());
    if (handle != null) { 
      MoveWindow(handle, PreferredScreen.workingArea.X, PreferredScreen.workingArea.Y,PreferredScreen.workingArea.Width,PreferredScreen.workingArea.Height, true);
      SetForegroundWindow(handle);
    }
    Thread.Sleep(500);
    // Need to send space first if on chrome, or it maximises to last known screen
    SendKeys.Send(" ");
    SendKeys.Send("{F11}"); 
