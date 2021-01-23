    [TestFixture]
    public class UnitTest
    {
        private Mock<IFoo> _mockFoo;
        [SetUp]
        public void Setup()
        {
            _mockFoo = new Mock<IFoo>(MockBehavior.Strict);
            var seq = new MockSequence();
            _mockFoo.InSequence(seq).SetupSet(m => m.Prop1 = It.IsAny<int>());
            _mockFoo.InSequence(seq).SetupSet(m => m.Prop2 = It.IsAny<string>());
            _mockFoo.InSequence(seq).Setup(m => m.WriteToTestStream());
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
            Assert.Catch<MockException>(() => sut.DoSomethingOutOfOrder());
        }
    }
