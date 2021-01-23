    DateTime temp;
    var dirInfo = new DirectoryInfo(MyApp.App_Code.Global.FileLocation)
                        .GetDirectories()
                        .Where(d => DateTime.TryParseExact(d.Name, 
                        "MMMyyyy", CultureInfo.InvariantCulture, 
                        DateTimeStyles.None, 
                        out temp))
                        .OrderBy(d => d.LastAccessTime).Last();
