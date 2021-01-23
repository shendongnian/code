    public class ProfileRepositoryFactory : IProfileRepositoryFactory
    {
        private readonly IProfileRepository aRepository;
        private readonly IProfileRepository bRepository;
    
        public ProfileRepositoryFactory(IProfileRepository aRepository,
            IProfileRepository bRepository)
        {
            if(aRepository == null)
            {
                throw new ArgumentNullException("aRepository");
            }
            if(bRepository == null)
            {
                throw new ArgumentNullException("bRepository");
            }
    
            this.aRepository = aRepository;
            this.bRepository = bRepository;
        }
    
        public IProfileRepository Create(string profileType)
        {
            if(profileType == "A")
            {
                return this.aRepository;
            }
            if(profileType == "B")
            {
                return this.bRepository;
            }
    
            // and so on...
        }
    }
