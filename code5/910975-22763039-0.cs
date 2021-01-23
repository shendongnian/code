    public class MultiBaseBindingGenerator : IBindingGenerator
    {
        public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return bindingRoot.Bind(type.BaseType).To(type);
            }
        }
    }
    public abstract class Foo
    {
    }
    public class SomeFoo : Foo
    {
    }
    public class SomeFooUser
    {
        public IEnumerable<Foo> Foos { get; set; }
        public SomeFooUser(IEnumerable<Foo> foos)
        {
            this.Foos = foos;
        }
    }
    public class Demo
    {
        [Fact]
        public void FactMethodName()
        {
            var kernel = new StandardKernel();
            kernel.Bind(x => x.FromThisAssembly()
                .SelectAllClasses()
                .InheritedFrom<Foo>()
                .BindWith<MultiBaseBindingGenerator>());
            kernel.Get<SomeFooUser>().Foos.Should().HaveCount(10);
        }
    }
