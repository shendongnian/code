    namespace ProviderManger
    {
      class ConfigHandler : ConfigurationSection
      {
        [ConfigurationProperty("providers")}
        public ProviderSettingsCollection Providers
        {
          get
          { return base["providers"] as ProviderSettingsCollection; }
    }}}
