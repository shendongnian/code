    public class UnitOfWork : IDisposable
    {
        private GenericRepository<Department> departmentRepository;
        private GenericRepository<Course> courseRepository;
        
        // here is the one we created, which is essentially a GenericRepository as well
        private UserRepository userRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository== null)
                {
                    this.userRepository= new UserRepository(context);
                }
                return this.userRepository;
            }
        }
       // ...
    }
