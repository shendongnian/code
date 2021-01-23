	public sealed class SecurityService {
		private ISecurityRepository _repository;
		public static SecurityService Instance { get; private set; }
	
		private SecurityService(ISecurityRepository repository) {
			_repository = repository;
		}
	
		public static void Configure(ISecurityRepository repository) {
			Instance = new SecurityService(repository);
		}
	
	
		public Model.LoginResponse GetUser(Model.UserRequest request) {
			if (string.IsNullOrEmpty(request.SecurityToken)) return null;
			User user = _repository.GetUserByToken(request.SecurityToken);
			if (user == null) throw new HabitationException("Invalid Security Token. Please login.", null);
			return AutoMapper.Mapper.Map<Model.LoginResponse>(user);
		}
	
	
		public Model.LoginResponse Login(Model.LoginRequest request) {
			string strPassword = EncryptPassword.GetMd5Hash(request.Password);
			User user = _repository.GetUser(request.Username, strPassword);
			return AutoMapper.Mapper.Map<Model.LoginResponse>(user);
		}
	
		internal User GetLoggedInUser(string securityToken) {
			if (string.IsNullOrEmpty(securityToken)) {
				return null;
			}
	
			User user = _repository.GetUserByToken(securityToken);
			if (user == null) throw new HabitationException("Invalid Security Token.", null);
			return user;
		}
	
	}
