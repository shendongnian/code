    public class ProfileController : Controller 
    {
        private IGenericRepository<Profile> _repository;
        private IUnitOfWork _unitOfWork = new DatabaseContext();  
        public ProfileController()  
        { 
            this._repository = new GenericRepository<Profile>(_unitOfWork);  
        }
    }
