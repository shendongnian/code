    public static void RemoveGroupPermission(string path, string group_name)
    {
          long begin = Datetime.Now.Ticks;
          DirectoryInfo dirInfo = new DirectoryInfo(path);
      
          DirectorySecurity dirSecurity = dirInfo.GetAccessControl();
          dirSecurity.RemoveAccessRuleAll(new FileSystemAccessRule(Environment.UserDomainName +
                                                                  @"\" + group_name, 0, 0));
          dirInfo.SetAccessControl(dirSecurity);
          long end = DateTime.Now.Ticks;
          Console.WriteLine("Tick : " + (end - begin));
      
    }
