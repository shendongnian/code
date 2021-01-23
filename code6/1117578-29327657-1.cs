    Process process = Process.GetProcesses().Where(p => p.MainWindowTitle == "Title of window").SingleOrDefault();
    if (process != null) {
          IntPtr wHnd = process.MainWindowHandle;
          Console.WriteLine("Minimized: "  + IsIconic(wHnd));
    }
