    [TestFixture]
    public class UnitTest
    {
        private bool _prop1Set = false;
        private bool _prop2Set = false;
        private Mock<IFoo> _mockFoo;
        [SetUp]
        public void Setup()
        {
            _mockFoo = new Mock<IFoo>();
            _mockFoo.SetupSet(m => m.Prop1).Callback(i => _prop1Set = true);
            _mockFoo.SetupSet(m => m.Prop2).Callback(s => _prop2Set = true);
            _mockFoo.Setup(m => m.WriteToTestStream())
                    .Callback(() => Assert.IsTrue(_prop1Set && _prop2Set));
        }
        [Test]
        public void EnsureInOrder()
        {
            var sut = new Bar(_mockFoo.Object);
            Assert.DoesNotThrow(() => sut.DoSomethingInOrder());
        }
        [Test]
        public void EnsureOutOfOrder()
        {
            var sut = new Bar(_mockFoo.Object);
            Assert.Catch<Exception>(() => sut.DoSomethingOutOfOrder());
        }
    }
