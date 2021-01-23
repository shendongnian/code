    [TestFixture]
    public class MoqTests
    {
        private Mock<IUserRepository> _repository;
        private UserService _userService;
        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IUserRepository>(MockBehavior.Strict);
            _userService = new UserService(_repository.Object);
        }
        [Test]
        public void RegisterUserWithItIsAny()
        {
            _repository.Setup(item => item.RegisterUser(It.IsAny<User>())).Returns(true);
            bool result = _userService.RegisterUser("abc");
            Assert.True(result);
        }
        [Test]
        public void RegisterUserWithMockOf()
        {
            _repository.Setup(item => item.RegisterUser(Mock.Of<User>())).Returns(true);
            bool result = _userService.RegisterUser("abc");
            Assert.True(result);
        }
        [TearDown]
        public void TearDown()
        {
            _repository.VerifyAll();
        }
    }
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool RegisterUser(string userName)
        {
            User user = new User { UserName = userName, CreatedOn = DateTime.Now };
            return _userRepository.RegisterUser(user);
        }
    }
    public interface IUserRepository
    {
        bool RegisterUser(User user);
    }
    public class User
    {
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
