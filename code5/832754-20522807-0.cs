    public abstract class A<T>
        where T : AbstractSomething
    {
        public abstract T foobar { get; }
    }
    public class B : A<ConcreteSomething>
    {
        public override ConcreteSomething foobar
        {
            get
            {
                return new ConcreteSomething();
            }
        }
    }
