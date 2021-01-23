    container.RegisterTypes(
        AllClasses.FromLoadedAssemblies(),
        WithMappings.FromAllInterfaces,
        WithName.Default,
        WithLifetime.Transient,
        type =>
        {
            // If settings type, load the setting
            if (!type.IsAbstract && typeof (ISettings).IsAssignableFrom(type))
            {
                return new[]
                {
                    new InjectionFactory((c, t, n) =>
                    {
                        var svc = (ISettings) c.Resolve(t);
                        return svc.LoadSetting(t);
                    })
                };
            }
            // Otherwise, no special consideration is needed
            return new InjectionMember[0];
        });
