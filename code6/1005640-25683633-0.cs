    public class AppSettingsModule : Module
    {
        private static List<Parameter> _appSettingParameters;
        private static List<Parameter> appSettingParameters
        {
            get
            {
                if (_appSettingParameters == null)
                {
                    // add all configs as named parameters
                    var allKeys = new List<string>();
                    allKeys.AddRange(ConfigurationManager.AppSettings.AllKeys);
                    // change first letter to lower case because we use first upper case in config section but lower case in constructor parameters
                    allKeys.AddRange(ConfigurationManager.AppSettings.AllKeys.Select(key => key.First().ToString().ToLower() + key.Substring(1)));
                    _appSettingParameters = allKeys.Select(key => new NamedParameter(key, new AppSetting(ConfigurationManager.AppSettings[key]))).Cast<Parameter>().ToList();
                }
                return _appSettingParameters;
            }
        }
        protected override void AttachToComponentRegistration(
          IComponentRegistry componentRegistry,
          IComponentRegistration registration)
        {
            // Any time a component is resolved, it goes through Preparing
            registration.Preparing += InjectAppSettingParameters;
        }
        protected void InjectAppSettingParameters(object sender, PreparingEventArgs e)
        {
            // add named parameters to every registration
            e.Parameters = e.Parameters.Union(appSettingParameters);
        }
    }
