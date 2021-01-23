    public class UserService: IUserService
    {
        IUserRepository userRepository;
        ... // ctor to inject repository
 
        public bool CheckEmailAvailability(string email)
        {
            var emailAvailable = !userRepository.GetUserEmails().Any(u => u.EmailAddress.Equals(email, StringComparison.InvariantCultureIgnoreCase));
            return emailAvailable;                            
        }
    }
    public class UserRepository: IUserRepository
    {
        ...
        
        public IEnumerable GetUserEmails()
        {
            // actually this context should be handled more centrally, included here for sake of illustration
            using (var context = new MyDbContext()) 
            {
                return repository.GetItems();
            }
        }
    }
