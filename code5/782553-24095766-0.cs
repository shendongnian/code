        TestEntities _context;
        public TestRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork as VoltEntities)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");
            _context = unitOfWork as TestEntities;
        }
    }
