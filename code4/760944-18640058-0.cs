    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Mocks are singletons.
        /// </summary>
        [Test]
        public void MocksAreSingletons()
        {
            using (var kernel = new NSubstituteMockingKernel())
            {
                var firstReference = kernel.Get<IDummyService>();
                var secondReference = kernel.Get<IDummyService>();
                firstReference.Should().BeSameAs(secondReference);
            }
        }
        /// <summary>
        /// Reals the objects are created for auto bindable types.
        /// </summary>
        [Test]
        public void RealObjectsAreCreatedForAutoBindableTypes()
        {
            using (var kernel = new NSubstituteMockingKernel())
            {
                var instance = kernel.Get<DummyClass>();
                instance.Should().NotBeNull();
            }
        }
        /// <summary>
        /// Reals objects are singletons.
        /// </summary>
        [Test]
        public void RealObjectsAreSingletons()
        {
            using (var kernel = new NSubstituteMockingKernel())
            {
                var instance1 = kernel.Get<DummyClass>();
                var instance2 = kernel.Get<DummyClass>();
                instance1.Should().BeSameAs(instance2);
            }
        }
        /// <summary>
        /// The injected dependencies are actually mocks.
        /// </summary>
        [Test]
        public void TheInjectedDependenciesAreMocks()
        {
            using (var kernel = new NSubstituteMockingKernel())
            {
                var instance = kernel.Get<DummyClass>();
                instance.DummyService.Do();
                instance.DummyService.Received().Do();
            }
        }
        public interface IDummyService
        {
            void Do();
        }
        public class DummyClass
        {
            public DummyClass(IDummyService dummyService)
            {
                this.DummyService = dummyService;
            }
            public IDummyService DummyService { get; set; }
        }
    }
