    public class Foo
    {
        private readonly IBar _bar;
        public Foo(IBar bar)
        {
            if (bar == null)
            {
                throw new ArgumentNullException("bar");
            }
            _bar = bar;
        }
    }
