    container.RegisterTypes(
        AllClasses.FromLoadedAssemblies().IsSetting(),
        WithMappings.FromAllInterfaces,
        WithName.Default,
        WithLifetime.Transient,
        SettingsRegistration.InjectionMembers);
    ...
    public static class SettingsRegistration
    {
        public static IEnumerable<Type> IsSetting(this IEnumerable<Type> types)
        {
            return types.Where(type => !type.IsAbstract && 
                                       typeof (ISettings).IsAssignableFrom(type));
        }
        public static IEnumerable<InjectionMember> InjectionMembers(Type type)
        {
            return new[] {new InjectionFactory(LoadSetting)};
        }
        public static ISettings LoadSetting(IUnityContainer container, 
                                            Type type, 
                                            string name)
        {
            var svc = (ISettings) container.Resolve(type, name);
            return svc.LoadSetting(type);
        }
    }
