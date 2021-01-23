    public static class MappingConfig
    {
         public static void ConfigureMap(DbModelBuilder modelBuilder)
         {
             modelBuilder.Configurations.Add(new ApplicationMap());
             modelBuilder.Configurations.Add(new ScriptMap());
         }
     }
