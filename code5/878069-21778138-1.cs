    [TestClass]
    public class RoleControllerTest
    {
        private Mock<IRoleRepository> _roleRepository;
    
        [SetUp]
        public void SetUp()
        {
    	_roleRepository = new Mock<IRoleRepository>();
    	
        }
    
    
        
        [TestMethod]
        public void IndexRoleController()
        {
        }
        [TestMethod]
        public void DetailsRoleController()
        {
            RoleController RC = new RoleController(_roleRepository.Object);
            var result = RC.Delete(1);
            Assert.IsNotNull(result);
        }
    }
