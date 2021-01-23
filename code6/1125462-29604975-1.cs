    public void Main()
    {
        int[] array = new int[] { 12, 15, 18, 64, 3, 68, 32 };
        object sync = new object();
        
        var results = new List<Result>();
    
        Parallel.ForEach
            (
                array,
                () => default(Result),
                (item, s, input) => input.Add(item),
                input => { lock (sync) results.Add(input); }
            );
        
        var aggregatedResult = results.Aggregate((acc, item) => acc.Add(item));
        
        aggregatedResult.Dump();
    }
    
    public struct Result
    {
      public readonly int Sum;
      public readonly int? Min;
      public readonly int? Max;
      
      public Result(int sum, int min, int max)
      {
        Sum = sum;
        Min = min;
        Max = max;
      }
      
      public Result Add(int item)
      {
        return
            new Result
            (
                Sum + item, 
                Min.HasValue && Min.Value < item ? Min.Value : item, 
                Max.HasValue && Max.Value > item ? Max.Value : item
            );
      }
      
      public Result Add(Result partialResult)
      {
        return
            new Result
            (
                Sum + partialResult.Sum, 
                Min.HasValue && Min.Value < partialResult.Min 
                  ? Min.Value : partialResult.Min.GetValueOrDefault(0), 
                Max.HasValue && Max.Value > partialResult.Max 
                  ? Max.Value : partialResult.Max.GetValueOrDefault(0)
            );
      }
    }
