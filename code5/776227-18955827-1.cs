    public class ControllerContext<T> where T : Controller
    {
        private static Lazy<T> _controllerFactory;
        private static IFixture _fixture;
        public ControllerContext()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _fixture.Customize<ControllerContext>(c => c.Without(x => x.DisplayMode));
            _controllerFactory = new Lazy<T>(() => _fixture.Create<T>());
        }
        protected static Mock<TDouble> For<TDouble>() where TDouble : class
        {
            var mock = _fixture.Freeze<Mock<TDouble>>();
            return mock;
        }
        protected static T ControllerUnderTest
        {
            get { return _controllerFactory.Value; }
        }
    }
    public class EXAMPLE_When_going_to_home_page : ControllerContext<HomeController>
    {
        static ISomeService SomeService;
        Because of = () =>
        {
            SomeService = For<ISomeService>();
            ControllerUnderTest.Index();
        };
        It should_do_something = () =>
        {
            //This throws a 'Invocation was not performed'
            SomeService.Verify(x => x.SomeMethod());
        };
        Establish context = () =>
        {
        };
    }
