    public interface IFoo
    {
        void Foo();
    }
    public interface IBar
    {
        void Bar();
    }
    public class FooService : IFoo
    {
        public void Foo()
        {
            Console.WriteLine("Foo");
        }
    }
    public class BarService : IBar
    {
        public void Bar()
        {
            Console.WriteLine("Bar");
        }
    }
    public class FooBar : IFoo, IBar
    {
        private readonly FooService fooService = new FooService();
        private readonly BarService barService = new BarService();
        public void Foo()
        {
            this.fooService.Foo();
        }
        public void Bar()
        {
            this.barService.Bar();
        }
    }
