    interface IDataPoint 
    { 
       SomeResultType Process();
    }
    class FirstKindDataPoint : IDataPoint 
    {
       SomeResultType Process(){...}
    };
    class SecondKindDataPoint : IDataPoint 
    {
       SomeResultType Process(){...}
    };
    class DataPointProcessor<T> where T: IDataPoint
    {
       void AcquireAndProcessDataPoints(){...}
    }
    
