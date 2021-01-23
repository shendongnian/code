    public class NamedParameterModule<TServiceType> : Module
    {
        private readonly string _parameterName;
        public NamedParameterModule(String parameterName)
        {
            this._parameterName = parameterName;
        }
        protected override void AttachToComponentRegistration(
            IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            KeyedService keyedService = registration.Services
                .OfType<KeyedService>()
                .FirstOrDefault(ks => ks.ServiceType == typeof(TServiceType));
                
            if (keyedService != null)
            {
                registration.Preparing += (sender, e) =>
                {
                    e.Parameters = e.Parameters.Concat(new Parameter[] { 
                        new NamedParameter(this._parameterName, keyedService.ServiceKey)
                    });
                };
            }
            
            base.AttachToComponentRegistration(componentRegistry, registration);
        }
    }
