    public interface IFilterable 
    {
       object FilterA {get; set;}
       object FilterB {get; set;}
    }
    
    public IEnumerable<T> FetchData<T>(int take, int skip, string guidRelatedA, string guidRelatedB, bool filterA,
                                 bool filterB, IEnumerable<T> dataToFilter) where T : IFilterable
    {
    ...
    }
