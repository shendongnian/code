    StringBuilder sb = new StringBuilder();
    sb.Append(Environment.GetFolderPath(Environment.SpecialFolder.Programs));
    sb.Append("\\");
    //publisher name is OneApp
    sb.Append("OneApp");
    sb.Append("\\");
    //product name is OneApp
    sb.Append("OneApp.appref-ms");
    string shortcutPath = sb.ToString();
    Console.WriteLine(shortcutPath);
    //Start the One App installed application from shortcut
    System.Diagnostics.Process.Start(shortcutPath);
