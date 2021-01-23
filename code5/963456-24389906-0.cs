    class ManagerAccessPoint
    {
        private ConfigManager _configManager;
        private SettingsManager _settingsManager;
        void Receive(Action action)
        {
            var configs = action as ConfigsAction;
            if (configs != null)
            {
                _configManager.Receive(configs);    
                return;
            }
            var settings = action as SettingsAction;
            if (settings != null)
            {
                _settingsManager.Receive(settings);    
                return;
            }
        }
    }
    class ConfigManager
    {
        void Receive(ConfigsAction action)
        {
          // repeat the same pattern here
          var setToZero = action as SetToZeroAction;
          if (setToZero != null)
          {
              // we have a setToZero action!
          }
          etc...
        }
    }
