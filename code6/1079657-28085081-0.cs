    Type t = o.GetType();
    o = getAppSetting("Setting", t);
    object getAppSetting(string key, Type targetType,)
    {
      string value = config.AppSettings.Settings[key].Value;
      if (t == typeof(Point))
      {
        string[] values = value.Split(',');
        return Convert.ChangeType(value, t);
      }
    }
   
