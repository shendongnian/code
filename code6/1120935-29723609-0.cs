    public Configuration()  {
      AutomaticMigrationsEnabled = false;
      using (var container = UnityConfig.GetConfiguredContainer())  {
            ....
      }
