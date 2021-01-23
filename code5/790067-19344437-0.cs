        abstract class TestBase<T, TThis> where TThis : TestBase<T, TThis>, new()
        {
            public T Thing { get; set; }
            public static TThis CreateNew(T t)
            {
                return new TThis { Thing = t };
            }
        }
        abstract class MiddleClass<TThis> 
             : TestBase<string, TThis> where TThis : TestBase<string, TThis>, new()
        {
            public abstract void DoSomething();
        }
        class RealClass : MiddleClass<RealClass>
        {
            public override void DoSomething()
            {
                // do something
            }
        }
