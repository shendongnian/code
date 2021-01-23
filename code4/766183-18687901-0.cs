    public interface IFoo
    {
        string X();
    }
    public abstract class AbstractFoo : IFoo
    {
        public abstract string X();
        protected internal Footilities Utilities { get; set; }
        protected internal abstract class Footilities
        {
            public abstract int Y();
        }
    }
    
    public class DefaultFoo : AbstractFoo
    {
        public DefaultFoo()
        {
            Utilities = new DefaultFootilities();
        }
        public override string X()
        {
            var y = Utilities.Y();
            return y.ToString();
        }
        protected internal class DefaultFootilities : Footilities
        {
            public override int Y()
            {
                return 1;
            }
        }
    }
    public abstract class AbstractWrappedFoo : AbstractFoo
    {
        protected readonly AbstractFoo Foo;
        public AbstractWrappedFoo(AbstractFoo foo)
        {
            Foo = foo;
        }
        public override string X()
        {
            return Foo.X();
        }
    }
    public class LoggedFoo : AbstractWrappedFoo
    {
        public LoggedFoo(AbstractFoo foo)
            : base(foo)
        {
            Foo.Utilities = new LoggedUtilities(Foo.Utilities);
        }
        public override string X()
        {
            return Foo.X();
        }
        protected internal class LoggedUtilities : Footilities
        {
            private readonly Footilities _utilities;
            public LoggedUtilities(Footilities utilities)
            {
                _utilities = utilities;
            }
            public override int Y()
            {
                Console.WriteLine("Sweet");
                return _utilities.Y();
            }
        }
    }
