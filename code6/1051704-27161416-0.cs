    var maxIndex = ConfigurationManager.AppSettings.AllKeys
                     .ToList()
                     .Where(k => k.StartsWith("confname"))
                     .Count();
    for (i = 1; i <= maxIndex; i++)
    {
      cbxConfig.Items.Add(ConfigurationManager.AppSettings["confname{0}",index])
    }
