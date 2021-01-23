    public abstract class AbstractFoo<TBar> where TBar : AbstractBar
    {
        public abstract TBar BarProperty { get; }
    }
    public class ConcreteFoo : AbstractFoo<ConcreteBar>
    {
        public override ConcreteBar BarProperty { get { ...; } }
    }
