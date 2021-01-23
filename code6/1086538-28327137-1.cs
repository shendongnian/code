    public class MyImmutable
    {
        // other stuff
        protected virtual MyImmutable GetNew(Dictionary<ImmutableKey, decimal> d)
        {
            return new MyImmutable(d);
        }
        public MyImmutable Apply(Func<decimal, decimal, decimal> aggFunc, MyImmutable y)
        {
            var aggregated = new Dictionary<ImmutableKey, decimal>(AllKeys.Count());
            foreach (ImmutableKey bt in AllKeys)
            {
                aggregated[bt] = aggFunc(this[bt], y[bt]);
            }
            return GetNew(aggregated);
        }
    }
    public class SubImmutable : MyImmutable
    {
        // other stuff
        protected override MyImmutable GetNew(Dictionary<ImmutableKey, decimal> d)
        {
            return new SubImmutable(SomeOtherValue, d);
        }
    }
