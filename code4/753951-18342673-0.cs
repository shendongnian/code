    public class ResultType 
    {
        public ClassOne ClassOne { get; set; }
        public string SomeOtherVar { get; set; }
    }
    return  
        from e in Context.pClassOneList 
        from r in SomeOtherList 
        select new ResultType
        {
            ClassOne = e,
            SomeOtherVar = r.SomeOtherVar
        };
