    Regex r = new Regex(@"\d\d\d");
    var list = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, 
                                   _globalSetting.CompanyCode + "trn*.*", 
                                   SearchOption.TopDirectoryOnly)
                                   .Where(x => r.IsMatch(Path.GetExtension(x)));
