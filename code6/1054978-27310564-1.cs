    public class Test
    {
        [Fact]
        public void Whoop()
        {
            var kernel = new StandardKernel();
            var contextMock = new Mock<IMyContext>();
            kernel.Bind<IMyContext>().ToConstant(contextMock.Object);
            kernel.Bind(x => x
                .FromThisAssembly()
                .SelectAllClasses()
                .InheritedFrom(typeof(IQueryHandler<,>))
                .BindSingleInterface()
                .Configure(QueryHandlerBindingConfigurator.Configure));
            contextMock.Setup(x => x.CustomRouteValue).Returns(string.Empty);
            kernel.Get<IQueryHandler<int, int>>()
                  .Should().BeOfType<QueryHandler>();
            contextMock.Setup(x => x.CustomRouteValue).Returns("AlternativeOne");
            kernel.Get<IQueryHandler<int, int>>()
                  .Should().BeOfType<AlternativeOneQueryHandler>();
            contextMock.Setup(x => x.CustomRouteValue).Returns("AlternativeTwo");
            kernel.Get<IQueryHandler<int, int>>()
                  .Should().BeOfType<AlternativeTwoQueryHandler>();
        }
    }
