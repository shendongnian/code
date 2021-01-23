    public class LocationTypesController : ApiController
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticatedUser _user;
        public LocationTypesController(ILocationRepository locationRepository,
                                       IUnitOfWork unitOfWork, 
                                       IAuthenticatedUser user)
        {
            if (locationRepository == null) 
                throw new ArgumentNullException("locationRepository");
            if (unitOfWork == null) 
                throw new ArgumentNullException("unitOfWork");
            if (user == null) 
                throw new ArgumentNullException("user");
            _locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
            _user = user;
        }
        public IEnumerable<LocationType> Get()
        {
            try
            {
                IEnumerable<Location> locations = _locationRepository.GetAllAuthorizedLocations(_user.UserName);
                _unitOfWork.Commit();
                return locations.Select(location => location.LocationType).Distinct().OrderBy(location => location.LocationTypeId);
            }
            catch (Exception)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }
