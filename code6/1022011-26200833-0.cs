    public class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, User>
    {
        private readonly IUserReader userRepository;
    
        public GetUserByEmailQueryHandler(IUserReader userRepository)
        {
            this.userRepository = userRepository;
        }
        public User Handle(GetUserByEmailQuery query)
        {
            return this.userRepository.FindByEmail(query.Email);
        }
    }
