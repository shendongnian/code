    public class DefaultConventionWithProxyScanner : ConfigurableRegistrationConvention
    {
        public override void Process(Type type, Registry registry)
        {
            if (!type.IsConcrete())
                return;
            var pluginType = this.FindPluginType(type);
            if (pluginType == null || !type.HasConstructors())
                return;
            registry.AddType(pluginType, type);
            var policy = CreatePolicy(pluginType);
            registry.Policies.Interceptors(policy);
            ConfigureFamily(registry.For(pluginType));
        }
        public virtual Type FindPluginType(Type concreteType)
        {
            var interfaceName = "I" + concreteType.Name;
            return concreteType.GetInterfaces().FirstOrDefault(t => t.Name == interfaceName);
        }
        public IInterceptorPolicy CreatePolicy(Type pluginType)
        {
            var genericPolicyType = typeof(InterceptorPolicy<>);
            var policyType = genericPolicyType.MakeGenericType(pluginType);
            return (IInterceptorPolicy)Activator.CreateInstance(policyType, new object[]{CreateInterceptor(pluginType), null});     
        }
        public IInterceptor CreateInterceptor(Type pluginType)
        {
            var genericInterceptorType = typeof(ProxyFuncInterceptor<>);
            var specificInterceptor = genericInterceptorType.MakeGenericType(pluginType);
            return (IInterceptor)Activator.CreateInstance(specificInterceptor);
        }
    }
