    public class TenantService : ServiceBase<TenantModel, TenantViewModel>, ITenantService
    {
        private readonly ITenantRepository _TenantRepository;
        public TenantService(ITenantRepository TenantRepository)
            : base(TenantRepository)
        {
            _TenantRepository = TenantRepository;
        }
    }
