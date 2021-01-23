    public class AppSettingsModule : Module
    {
        protected override void AttachToComponentRegistration(
          IComponentRegistry componentRegistry,
          IComponentRegistration registration)
        {
            // Any time a component is resolved, it goes through Preparing
            registration.Preparing += InjectAppSettingParameters;
        }
        private void InjectAppSettingParameters(object sender, PreparingEventArgs e)
        {
            // check if parameter is of type AppSetting and if it is return AppSetting using the parameter name
            var appSettingParameter = new ResolvedParameter((par, ctx) => par.ParameterType == typeof(AppSetting), (par, ctx) => new AppSetting(ConfigurationManager.AppSettings[par.Name]));
            e.Parameters = e.Parameters.Union(new List<Parameter>{ appSettingParameter});
        }
    }
