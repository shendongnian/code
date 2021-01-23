    [TestFixture]
    public class FooControllerTests
    {
        [Test]
        public void PersistingNullFooMustThrow()
        {
            var systemUnderTest = new FooController(new Mock<IFooSaverService>().Object);
            Assert.Throws<ArgumentNullException>(() => systemUnderTest.PersistTheFoo(null));
        }
        [Test]
        public void EnsureOldFoosAreNotSaved()
        {
            var mockFooSaver = new Mock<IFooSaverService>();
            var systemUnderTest = new FooController(mockFooSaver.Object);
            systemUnderTest.PersistTheFoo(new Foo{Name = "Old Foo", ExpiryDate = new DateTime(1999,1,1)});
            mockFooSaver.Verify(m => m.Save(It.IsAny<Foo>()), Times.Never);
        }
        [Test]
        public void EnsureNewFoosAreSaved()
        {
            var mockFooSaver = new Mock<IFooSaverService>();
            var systemUnderTest = new FooController(mockFooSaver.Object);
            systemUnderTest.PersistTheFoo(new Foo { Name = "New Foo", ExpiryDate = new DateTime(2038, 1, 1) });
            mockFooSaver.Verify(m => m.Save(It.IsAny<Foo>()), Times.Once);
        }
    }
