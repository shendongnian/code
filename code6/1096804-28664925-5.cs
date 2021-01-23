            var repository = new Repository<Domain, Entity>();
            IEntityRepository<Entity> entityRepo = repository; // IMPORTANT! Casting to IEntityRepository
            IDomainRepository<Domain> domainRepo = repository; // IMPORTANT! Casting to IDomainRepository
            IEnumerable<Entity> entityModels = entityRepo.GetAll();
            IEnumerable<Domain> domainModels = domainRepo.GetAll();
            RepositoryBase<Entity> repository2 = new RepositoryBase<Entity>();
            IEnumerable<Entity> entityModels2 = repository2.GetAll();
