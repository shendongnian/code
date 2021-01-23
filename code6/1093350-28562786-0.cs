        public class DataContextRegistrationSource : IRegistrationSource
        {
            public Boolean IsAdapterForIndividualComponents
            {
                get { return true; }
            }
            public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
            {
                if (service == null)
                {
                    throw new ArgumentNullException("service");
                }
                if (registrationAccessor == null)
                {
                    throw new ArgumentNullException("registrationAccessor");
                }
                IServiceWithType ts = service as IServiceWithType;
                if (ts == null || !(ts.ServiceType.IsGenericType && ts.ServiceType.GetGenericTypeDefinition() == typeof(DataContext<>)))
                {
                    yield break;
                }
                yield return RegistrationBuilder.ForType(ts.ServiceType)
                                                .AsSelf()
                                                .WithParameter(new NamedParameter("databaseName", "test"))
                                                .WithParameter(new NamedParameter("serverName", "test2"))
                                                .CreateRegistration();
            }
        }
