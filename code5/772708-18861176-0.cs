    public class UserControllerServiceFactory : IUserControllerServiceFactory {
        public IUserService CreateUserService() {
            return _container.Get<IUserService>();
        }
        public IBookService CreateBookService() {
            return _container.Get<IBookService>();
        }
        // etc.
    }
