    public abstract class TestAbstractClass<T>
    {
        protected virtual void Method(ref IQueryable<T> query)
        {
        }
    }
    class TestA : TestAbstractClass<Person>
    {
        protected override void Method(ref IQueryable<Person> query)
        {
            var q = query.OrderBy(p => p.Forename);
        }
    }
