    [TestClass]
    public class TestClass
    {
        Mock<AlbumController> mockedTarget
        AlbumController target
        
        [TestInitialize]
        public void Init()
        {
            mockedTarget = new Mock<AlbumController>();
            target = mockedTarget.Object;
        }
    
        [Test]
        public void Test()
        {
            mockedTarget.Setup(x => x.CheckAccessAsync(It.IsAny<string>(),
                It.IsAny<string[]>()))
                .Returns(Task.FromResult(true));
    
            var result = target.Get(1);
    
            // Assert
        }
    
    }
