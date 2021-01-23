    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void SomeTest()
        {
            var models = new ... // collection
            var repository = new Mock<RepositoryBase<Model>>();
            repository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(models));
            var viewModel = new MainViewModel(repository.Object); 
            
            // Assert stuff...
        }
    }
