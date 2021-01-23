    public abstract class TestAbstractClass<T>
    {
        public abstract void Method(ref IQueryable<T> query);
    }
    
    public class TestA : TestAbstractClass<Person>
    {
       // T in this class is an object with a property called Forename
       public override void Method(ref IQueryable<T> query)
       {
           query = query.OrderBy(o=>o.Forename); // unaware of property forename
       }
    }
    
    public class TestB:TestAbstractClass<Glove>
    {
       // T in this class is an object with a property called HandSize
       public override void Method(ref IQueryable<T> query)
       {
           query = query.OrderBy(o=>o.HandSize); // unaware of property
       }
    }
