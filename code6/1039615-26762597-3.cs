     [TestClass]
        public class UnitTest1
        {
            private IRepository<Entity> _repository;
            private SomeService _target;
    
            [TestInitialize]
            public void SetUp()
            {
                _repository = MockRepository.GenerateStub<IRepository<Entity>>();
                _target = new SomeService(_repository);
            }
    
    
            [TestMethod]
            public void TestMethod1()
            {
                _repository.Stub(x => x.GetAll()).Return(new List<Entity>().AsQueryable());
    
                //Test your target
            }
        }
