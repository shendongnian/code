    namespace LinqPlayground
    {
        class Program
        {
            static void Main(string[] args)
            {
                var someInts = new List<int>
                {
                    1,2,3,4,5,6,6,7
                };
                
                var queryObjectPattern = new QueryObjectPattern<int>();
                queryObjectPattern.AddOr(i => i == 5);
                queryObjectPattern.AddOr(i => i == 7);
    
                var intsThatPassed = queryObjectPattern.GetItemsUsingOrClauses(someInts);
                foreach (var i in intsThatPassed)
                {
                    Console.WriteLine("{0} passed!", i);    
                }
                
            }
    
            public class QueryObjectPattern<T>
            {
                private readonly List<Func<T, bool>> _funcsToApply;
    
                public QueryObjectPattern()
                {
                    _funcsToApply =  new List<Func<T, bool>>();
                }
    
                public void AddOr(Func<T, bool> orClause)
                {
                    _funcsToApply.Add(orClause);
                }
    
                public IEnumerable<T> GetItemsUsingOrClauses(IEnumerable<T> items)
                {
                    var itemsThatPassed = new List<T>();
                    foreach (var func in _funcsToApply)
                    {
                        itemsThatPassed.AddRange(items.Where(func));
                    }
                    return itemsThatPassed;
                }
            }
        }
    }
