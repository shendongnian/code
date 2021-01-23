    internal interface IContext {
        void initialize();
    }
    public class Context : IContext {
        public void initialize() { }
    }
    public class ServiceFactory {
        public static Service createService() { return new Service(new Context()); }
    }
    public class Service {
        public Context getContext() { return context as Context; }
        internal Service(IContext ctx) {
            context = ctx;
            context.initialize();
        }
        private IContext context;
    }
    [TestFixture()]
    public class ServiceTest {
        [Test()]
        public void shouldInitializeContextWhenConstructed() {
            Mock<IContext> mockContext = new Mock<IContext>();
            new Service(mockContext.Object);
            mockContext.Verify(c => c.initialize(), Times.Once());
        }
    }
