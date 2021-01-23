    public class InvalidateGetCitiesByCountryQueryCache : IEventHandler<CityAdded>
    {
        private readonly IQueryCache queryCache;
        private readonly IRepository<City> cityRepository;
        public InvalidateGetCitiesByCountryQueryCache(...) { ... }
        public void Handle(CityAdded e)
        {
            Guid countryId = this.cityRepository.GetById(e.CityId).CountryId;
            this.queryCache.Invalidate(new GetCitiesByCountryQuery(countryId));
        }
    }
