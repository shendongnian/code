    using FluentAssertions;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Xunit;
    namespace NinjectTest.ClosedGenericConvention
    {
        public interface ICommand<TParam> { }
        public class FloatCommand : ICommand<float> { }
        public class IntCommand : ICommand<int> { }
        public class Test
        {
            [Fact]
            public void Fact()
            {
                var kernel = new StandardKernel();
                kernel.Bind(x => x.FromThisAssembly()
                    .SelectAllClasses()
                    .InheritedFrom(typeof(ICommand<>))
                    .BindSingleInterface());
                kernel.Get<ICommand<float>>().Should().BeOfType<FloatCommand>();
                kernel.Get<ICommand<int>>().Should().BeOfType<IntCommand>();
            }
        }
    }
