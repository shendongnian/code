    public interface IUserRepository
    {
        void Insert(User user);
        ...
        IEnumerable<User> GetByDepartmentId(int deptId);
    }
    public interface IContactLogRepository
    {
        void Insert(ContactLog contactLog); 
    }
    public class EmailService
    {
        private readonly IUserRepository _userRepo;
        private readonly IContactLogRepository _contactLogRepo;
        public EmailService(IUserRepository userRepo, IContactLogRepository contLogRepo) {
            _userRepo = userRepo;
            _contactLogRepo = contLogRepo;
        }
        public void EmailDepartment(int deptId, string message) {
            var employees = _userRepo.GetByDepartmentId(deptId);
            foreach (var emp in employees) {
                Email(emp.Email, message);
                _contactLogRepo.Insert(new ContactLog {
                    EmployeeId = emp.Id,
                    Message = message
                });
            }
        }
        private void Email(string address, string message) {
            ...
        }
    }
