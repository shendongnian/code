    Dictionary<string, Dictionary<string, DateTime>> fileLaunchTimes = new Dictionary<string,       Dictionary<string, DateTime>>();
    Dictionary<string, DateTime> dict = new Dictionary<string, DateTime>();
    dict.Add("Monday", DateTime.Now); //etc (replace datetime.now with whatever time you want
    dict.Add("Tuesday", DateTime.Now);
    fileLaunchTimes.Add("filename", dict);
