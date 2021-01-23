    public class UserService {
        private static InMemoryUserService _service = null;
        public static InMemoryUserService Get() {
            if(_service == null)
                _service = new InMemoryUserService(Users.Get());
            return _service;
        }
    }
