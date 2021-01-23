     public class DefaultConventionScanner : ConfigurableRegistrationConvention
    {
        public override void Process(Type type, Registry registry)
        {
            if (!TypeExtensions.IsConcrete(type))
                return;
            Type pluginType = this.FindPluginType(type);
            if (pluginType == null || !TypeExtensions.HasConstructors(type))
                return;
            registry.AddType(pluginType, type);
            this.ConfigureFamily(registry.For(pluginType, (ILifecycle)null));
        }
        public virtual Type FindPluginType(Type concreteType)
        {
            string interfaceName = "I" + concreteType.Name;
            return Enumerable.FirstOrDefault<Type>((IEnumerable<Type>)concreteType.GetInterfaces(), (Func<Type, bool>)(t => t.Name == interfaceName));
        }
    }
