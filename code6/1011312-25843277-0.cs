        using StructureMap;
        private readonly IUnitOfWork _uow;
        private readonly IAccount _acc;
    
        public CodeFirstMembershipProvider()
        {
            _uow = ObjectFactory.GetInstance<IUnitOfWork>();
            _acc = ObjectFactory.GetInstance<IAccount>();
        }
