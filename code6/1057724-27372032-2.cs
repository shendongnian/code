    container.RegisterTypes(new SettingsRegistrationConvention(
        AllClasses.FromLoadedAssemblies()));
    ...
    public class SettingsRegistrationConvention : RegistrationConvention
    {
        private readonly IEnumerable<Type> _scanTypes;
        public SettingsRegistrationConvention(IEnumerable<Type> scanTypes)
        {
            if (scanTypes == null)
                throw new ArgumentNullException("scanTypes");
            _scanTypes = scanTypes;
        }
        public override IEnumerable<Type> GetTypes()
        {
            return _scanTypes.Where(type => !type.IsAbstract && 
                                            typeof (ISettings).IsAssignableFrom(type));
        }
        public override Func<Type, IEnumerable<Type>> GetFromTypes()
        {
            return WithMappings.FromAllInterfaces;
        }
        public override Func<Type, string> GetName()
        {
            return WithName.Default;
        }
        public override Func<Type, LifetimeManager> GetLifetimeManager()
        {
            return WithLifetime.Transient;
        }
        public override Func<Type, IEnumerable<InjectionMember>> GetInjectionMembers()
        {
            return type => new[]
            {
                new InjectionFactory((c, t, n) =>
                {
                    var svc = (ISettings) c.Resolve(t);
                    return svc.LoadSetting(t);
                })
            };
        }
    }
