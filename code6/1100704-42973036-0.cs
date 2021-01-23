    public interface IGenericDecoratorRegistrationBuilder : IHideObjectMembers
    {
        IGenericDecoratorRegistrationBuilder Decorator(Type decoratorType, Func<Type, bool> filter = null, Func<Type, IEnumerable<Parameter>> paramsGetter = null); 
    }
    public static class GenericDecorators
    {       
        public class GenericDecoratorRegistration
        {
            public Type Type;
            public Func<Type, bool> Filter;
            public Func<Type, IEnumerable<Parameter>> ParamsGetter;
        }
        class GenericDecoratorRegistrationBuilder : IGenericDecoratorRegistrationBuilder
        {
            readonly List<GenericDecoratorRegistration> decorators = new List<GenericDecoratorRegistration>();
            public IEnumerable<GenericDecoratorRegistration> Decorators
            {
	            get { return decorators; }
            }
            public IGenericDecoratorRegistrationBuilder Decorator(Type decoratorType, Func<Type, bool> filter, Func<Type, IEnumerable<Parameter>> paramsGetter)
            {
                if (decoratorType == null)
		            throw new ArgumentNullException("decoratorType");
                if (!decoratorType.IsGenericTypeDefinition)
                    throw new ArgumentException(null, "decoratorType");
                var decorator = new GenericDecoratorRegistration
                {
                    Type = decoratorType,
                    Filter = filter,
                    ParamsGetter = paramsGetter
                };
                decorators.Add(decorator);
                return this;
            }
        }
        class GenericDecoratorRegistrationSource : IRegistrationSource
        {
            readonly Type decoratedType;
            readonly IEnumerable<GenericDecoratorRegistration> decorators;
            readonly object fromKey;
            readonly object toKey;
            public GenericDecoratorRegistrationSource(Type decoratedType, IEnumerable<GenericDecoratorRegistration> decorators, object fromKey, object toKey)
	        {
                this.decoratedType = decoratedType;
                this.decorators = decorators;
                this.fromKey = fromKey;
                this.toKey = toKey;
            }
            public bool IsAdapterForIndividualComponents
            {
                get { return true; }
            }
            public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
            {
                var swt = service as IServiceWithType;
                KeyedService ks;
                if (swt == null ||
                    (ks = new KeyedService(fromKey, swt.ServiceType)) == service ||
                    !swt.ServiceType.IsGenericType || swt.ServiceType.GetGenericTypeDefinition() != decoratedType)
                    return Enumerable.Empty<IComponentRegistration>();
                
                return registrationAccessor(ks).Select(cr => new ComponentRegistration(
                        Guid.NewGuid(),
                        BuildActivator(cr, swt),
                        cr.Lifetime,
                        cr.Sharing,
                        cr.Ownership,
                        new[] { toKey != null ? (Service)new KeyedService(toKey, swt.ServiceType) : new TypedService(swt.ServiceType) },
                        cr.Metadata,
                        cr));
            }
            DelegateActivator BuildActivator(IComponentRegistration cr, IServiceWithType swt)
            {
                var limitType = cr.Activator.LimitType;
                var actualDecorators = decorators
                    .Where(d => d.Filter != null ? d.Filter(limitType) : true)
                    .Select(d => new { Type = d.Type, Parameters = d.ParamsGetter != null ? d.ParamsGetter(limitType) : Enumerable.Empty<Parameter>() })
                    .ToArray();
                return new DelegateActivator(cr.Activator.LimitType, (ctx, p) =>
                {
                    var typeArgs = swt.ServiceType.GetGenericArguments();
                    var service = ctx.ResolveKeyed(fromKey, swt.ServiceType);
                    foreach (var decorator in actualDecorators)
                    {
                        var decoratorType = decorator.Type.MakeGenericType(typeArgs);
                        var @params = decorator.Parameters.Concat(new[] { new TypedParameter(swt.ServiceType, service) });
                        var activator = new ReflectionActivator(decoratorType, new DefaultConstructorFinder(), new MostParametersConstructorSelector(),
                            @params, Enumerable.Empty<Parameter>());
                        service = activator.ActivateInstance(ctx, @params);
                    }
                    return service;
                });
            }
        }
        public static IGenericDecoratorRegistrationBuilder RegisterGenericDecorators(this ContainerBuilder builder, Type decoratedServiceType, object fromKey, object toKey = null)
        {
	        if (builder == null)
		        throw new ArgumentNullException("builder");
    
            if (decoratedServiceType == null)
                throw new ArgumentNullException("decoratedServiceType");
            if (!decoratedServiceType.IsGenericTypeDefinition)
                throw new ArgumentException(null, "decoratedServiceType");
            var rb = new GenericDecoratorRegistrationBuilder();
            builder.RegisterCallback(cr => cr.AddRegistrationSource(new GenericDecoratorRegistrationSource(decoratedServiceType, rb.Decorators, fromKey, toKey)));
            return rb;
        }
    }
