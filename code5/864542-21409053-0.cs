    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private EFDbContext context = new EFDbContext ();
        internal ICityRepository cityRepo;
        public ICityRepository CityRepository
        {
            get
            {
                if (cityRepo== null)
                {
                    cityRepo = new EFCityRepository(context);
                }
                return account;
            }
        }
    }
