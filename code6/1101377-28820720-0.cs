        public abstract class BaseFoo
        {
            public virtual string FooText { get; set; }
        }
        public class ConcreteFoo : BaseFoo
        {
            public override string FooText { get; set; }
        }
