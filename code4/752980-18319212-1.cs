    class AggregateResult
    {
        public object CallingObject;
        public Result Result;
        public static AggregateResult Create<T>(T t, Func<T,Result> func) 
        { 
            return new AggregateResult() { CallingObject = t, Result = func(t) }; 
        }
    }
    IEnumerable<AggregateResult> AggregateResults(Func<AggregateResult> func, params Func<AggregateResult>[] otherFuncs)
    {
        yield return func();
        foreach (var otherFunc in otherFuncs)
            yield return otherFunc();
    }
    //Usage:
    var results = AggregateResults(
                () => AggregateResult.Create(A, x=>x.Something()),
                () => AggregateResult.Create(B, x=>x.SomethingElse(3)),
                () => AggregateResult.Create(C, x=>x.SomethingOtherThing("apple")));
    var failedResult = results.FirstOrDefault(x => x.Result.Failed);
    if (failedResult != null) return new Status() { Failed = failedResult.CallingObject.GetType().ToString() };
