    public class PartitionTuple<T>
    {
      IEnumerable<T> source;
      IList<T> before, after;
      Func<T, bool> partition;
    	
      public PartitionTuple(IEnumerable<T> source, Func<T, bool> partition)
      {
        this.source = source;
        this.partition = partition;
      }
    	
      private void EnsureMaterialized()
      {
        if(before == null)
        {
          before = new List<T>();
          after = new List<T>();
    			
          using(var enumerator = source.GetEnumerator())
          {
            while(enumerator.MoveNext() && !partition(enumerator.Current))
            {
              before.Add(enumerator.Current);	
            }
    			
            while(!partition(enumerator.Current) && enumerator.MoveNext());
    			
            while(enumerator.MoveNext())
            {
              after.Add(enumerator.Current);
            }
          }
        }
      }
    	
      public IEnumerable<T> Before 
      { 
        get
        {
          EnsureMaterialized();
          return before;
        }
      }
    	
      public IEnumerable<T> After
      {
        get
        {
          EnsureMaterialized();
          return after;
        }
      }
    }
    
    public static class Extensions
    {
      public static PartitionTuple<T> Partition<T>(this IEnumerable<T> sequence, Func<T, bool> partition)
      {
        return new PartitionTuple<T>(sequence, partition);
      }
    }
