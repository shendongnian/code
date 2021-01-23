        private Func<IDomainService> DomainServiceFactory { get; set; }
        private IDomainService DomainService
        {
            get { return DomainServiceFactory(); }
        }
