    public static void RemoveGroupPermission(string path,string group_name)
    {
          long begin = Datetime.Now.Ticks;
          DirectoryInfo dirInfo = new DirectoryInfo(Path);
      
          DirectorySecurity dirSecurity = dirInfo.GetAccessControl();
          dirSecurity.RemoveAccessRuleAll(new FileSystemAccessRule(Environment.UserDomainName +
                                                                  @"\" + GroupName, 0, 0));
          dirInfo.SetAccessControl(dirSecurity);
          long end = DateTime.Now.Ticks;
          Console.WriteLine("Tick : " + (end - begin));
      
    }
