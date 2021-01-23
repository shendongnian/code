    var maxIndex = ConfigurationManager.AppSettings.AllKeys
                     .ToList()
                     .Where(k => k.StartsWith("confname"))
                     .Count();
    for (var index = 1; index <= maxIndex; index++)
    {
      cbxConfig.Items.Add(ConfigurationManager.AppSettings["confname{0}", index])
    }
