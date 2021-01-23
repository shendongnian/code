    // this might only work as long as there's no successor to Windows 8.1
    public Version GetVersion()
    {
       var reportedVersion = System.Environment.OSVersion.Version;
       if (reportedVersion.Major==6 && reportedVersion.Minor==2)
       {
          bool _IsWindows8Point1OrGreater = Type.GetType("Windows.UI.Xaml.Controls.Flyout, Windows.UI.Xaml, ContentType=WindowsRuntime", false) != null;
          if(_IsWindows8Point1OrGreater )
          reportedVersion = new Version(6,3); 
       }
       return reportedVersion;
    }
