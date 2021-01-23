    public class AddCityCommandHandler : ICommandHandler<AddCityCommand>
    {
        private readonly IRepository<City> cityRepository;
        private readonly IGuidProvider guidProvider;
        private readonly IDomainEventPublisher eventPublisher;
        public AddCountryCommandHandler(IRepository<City> cityRepository,
            IGuidProvider guidProvider, IDomainEventPublisher eventPublisher) { ... }
        public void Handle(AddCityCommand command)
        {
            City city = cityRepository.Create();
            city.Id = this.guidProvider.NewGuid();
            city.CountryId = command.CountryId;
            this.eventPublisher.Publish(new CityAdded(city.Id));
        }
    }
