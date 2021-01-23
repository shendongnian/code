//Dependency Injection
public static void RegisterTypes(IUnityContainer container)
		{
			// Register manager mappings.
			container.RegisterType<IDatabaseContextProvider, EntityContextProvider>(new PerResolveLifetimeManager());
		}
	}
//Test Setup
        /// <summary>
        ///     Mocked <see cref="IrdEntities" /> context to be used in testing.
        /// </summary>
        private Mock<CCMSEntities> _irdContextMock;
		/// <summary>
		///		Mocked <see cref="IDatabaseContextProvider" /> context to be used in testing.
		/// </summary>
		private Mock<IDatabaseContextProvider> _EntityContextProvider;
...
            
			_irdContextMock = new Mock<CCMSEntities>();
			_irdContextMock.Setup(m => m.Outbreaks).Returns(new Mock<DbSet<Outbreak>>().SetupData(_outbreakData).Object);
            _irdContextMock.Setup(m => m.FDI_Number_Counter).Returns(new Mock<DbSet<FDI_Number_Counter>>().SetupData(new List<FDI_Number_Counter>()).Object);
			_EntityContextProvider = new Mock<IDatabaseContextProvider>();
			_EntityContextProvider.Setup(m => m.Context).Returns(_irdContextMock.Object);
            _irdOutbreakRepository = new IrdOutbreakRepository(_EntityContextProvider.Object, _loggerMock.Object);
// Usage in the Class being tested:
//Constructor
		public IrdOutbreakRepository(IDatabaseContextProvider entityContextProvider, ILogger logger)
		{
			_entityContextProvider = entityContextProvider;
			_irdContext = entityContextProvider.Context;
			_logger = logger;
		}
		/// <summary>
		///		The wrapper for the Entity Framework context and transaction.
		/// </summary>
		private readonly IDatabaseContextProvider _entityContextProvider;
		// The usage of a transaction that automatically gets mocked because the return type is void.
		_entityContextProvider.BeginTransaction();
...
