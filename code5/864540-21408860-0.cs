    public class EFCityRepository : ICityRepository
    { 
        public EFCityRepository( EFDbContext context )
        {
            this.context = context;
        }        
        private EFDbContext context;
        public bool Create(City cityToCreate)
        {
            ...
        }
        public City Get(int cityID)
        {
            ...
        }
    }
