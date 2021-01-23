    string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    string newpath = System.IO.Path.Combine(appData, "My_Application", "My_Application.exe");
    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(newpath));
    File.Copy(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString(), newpath);
    RegistryKey startup = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
    startup.SetValue("My_Application", newpath);
