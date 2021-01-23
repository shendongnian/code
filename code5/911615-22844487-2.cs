    public static class AutofacExtensions
    {
        // DynamicProxy2 generator for creating proxies
        private static readonly ProxyGenerator generator = new ProxyGenerator();
        /// <summary>
        /// Intercept ALL registered interfaces with provided interceptors.
        /// Override Autofac activation with a Interface Proxy.
        /// Does not intercept classes, only interface bindings.
        /// </summary>
        /// <param name="builder">Contained builder to apply interceptions to.</param>
        /// <param name="interceptors">List of interceptors to apply.</param>
        public static void InterceptInterfacesBy(this ContainerBuilder builder, params IInterceptor[] interceptors)
        {
            builder.RegisterCallback((componentRegistry) =>
            {
                foreach (var registration in componentRegistry.Registrations)
                {
                    InterceptRegistration(registration, interceptors);
                }
            });
        }
        /// <summary>
        /// Intercept a specific component registrations.
        /// </summary>
        /// <param name="registration">Component registration</param>
        /// <param name="interceptors">List of interceptors to apply.</param>
        private static void InterceptRegistration(IComponentRegistration registration, params IInterceptor[] interceptors)
        {
            // proxy does not get allong well with Activated event and registrations with Activated events cannot be proxied.
            // They are casted to LimitedType in the IRegistrationBuilder OnActivated method. This is the offending Autofac code:
            // 
            // public IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> OnActivated(Action<IActivatedEventArgs<TLimit>> handler)
            // {
            //    if (handler == null) throw new ArgumentNullException("handler");
            //    RegistrationData.ActivatedHandlers.Add(
            //        (s, e) => handler(new ActivatedEventArgs<TLimit>(e.Context, e.Component, e.Parameters, (TLimit)e.Instance)));
            //    return this;
            // }
            Delegate[] handlers = GetActivatedEventHandlers(registration);
            if (handlers.Any(h => handlers[0].Method.DeclaringType.Namespace.StartsWith("Autofac")))
            {
                return;
            }
         
            registration.Activating += (sender, e) =>
            {
                Type type = e.Instance.GetType();
                if (e.Component.Services.OfType<IServiceWithType>().Any(swt => !swt.ServiceType.IsInterface || !swt.ServiceType.IsVisible) || 
                    // prevent proxying the proxy 
                    type.Namespace == "Castle.Proxies")
                {
                    return;
                }
                var proxiedInterfaces = type.GetInterfaces().Where(i => i.IsVisible).ToArray();
                if (!proxiedInterfaces.Any())
                {
                    return;
                }
                // intercept with all interceptors
                var theInterface = proxiedInterfaces.First();
                var interfaces = proxiedInterfaces.Skip(1).ToArray();
                e.Instance = generator.CreateInterfaceProxyWithTarget(theInterface, interfaces, e.Instance, interceptors);
            };
        }
        /// <summary>
        /// Get Activated event handlers for a registrations
        /// </summary>
        /// <param name="registration">Registration to retrieve events from</param>
        /// <returns>Array of delegates in the event handler</returns>
        private static Delegate[] GetActivatedEventHandlers(IComponentRegistration registration)
        {
            FieldInfo eventHandlerField = registration.GetType().GetField("Activated", BindingFlags.NonPublic | BindingFlags.Instance);
            var registrations = eventHandlerField.GetValue(registration);
            System.Diagnostics.Debug.WriteLine(registrations);
            return registrations.GetType().GetMethod("GetInvocationList").Invoke(registrations, null) as Delegate[];
        }
    }
