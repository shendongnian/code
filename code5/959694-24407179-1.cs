        public object Create(object request, ISpecimenContext context)
        {
            if (!SubstitutionSpecification.IsSatisfiedBy(request))
                return new NoSpecimen(request);
            var substitute = Builder.Create(request, context);
            if (substitute == null)
                return new NoSpecimen(request);
            NSubstituteDefaultValueConfigurator.Configure(
                substitute.GetType(), 
                substitute,
                new AutoFixtureDefaultValueFactory(context));
            return substitute;
        }
        private class AutoFixtureDefaultValueFactory : IDefaultValueFactory
        {
            private readonly ISpecimenContext _context;
            public AutoFixtureDefaultValueFactory(ISpecimenContext context)
            {
                _context = context;
            }
            public T GetDefault<T>()
            {
                return _context.Create<T>();
            }
        }
