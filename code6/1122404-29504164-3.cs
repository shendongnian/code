    public class FilterRegistrationSource : IRegistrationSource
    {
        private static MethodInfo _createFilteredRegistrationMethod = typeof(FilterRegistrationSource).GetMethod("CreateFilteredRegistration");
        public Boolean IsAdapterForIndividualComponents
        {
            get
            {
                return false;
            }
        }
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            IServiceWithType serviceWithType = service as IServiceWithType;
            if (serviceWithType == null)
            {
                yield break;
            }
            Type serviceType = serviceWithType.ServiceType;
            if (!serviceType.IsClosedTypeOf(typeof(IEnumerable<>)))
            {
                yield break;
            }
            Type elementType = new Type[] { serviceType }.Concat(serviceType.GetInterfaces())
                                          .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                                          .Select(t => t.GetGenericArguments()[0])
                                          .First();
            yield return (IComponentRegistration)FilterRegistrationSource._createFilteredRegistrationMethod.MakeGenericMethod(elementType)
                                                                         .Invoke(this, new Object[] { serviceWithType });
        }
        public IComponentRegistration CreateFilteredRegistration<T>(IServiceWithType serviceWithType)
        {
            return RegistrationBuilder.ForDelegate((cc, p) => cc.ComponentRegistry
                                                                .RegistrationsFor(serviceWithType.ChangeType(typeof(T)))
                                                                .Where(r => !r.Activator.LimitType.GetCustomAttributes(typeof(ContractClassForAttribute), false).Any())
                                                                .Select(r => r.Activator.ActivateInstance(cc, p))
                                                                .Cast<T>())
                                      .As((Service)serviceWithType)
                                      .CreateRegistration();
        }
    }
