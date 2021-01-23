    public static class PerfCounterManager
    {
      public static List<PerfCounter> GetCounters() 
      {
    	return new List<PerfCounter> 
    	{
          new SortedSet<PerfCounter>
          {
    	    new PerfCounter
    	    {
    	      CounterTypeId = (int) SampleEnum.Sample1,
    	      CounterName = GetEnumDescription(CounterType.Sample1)
    	    },
    	    new PerfCounter
    	    {
    	      CounterTypeId = (int) SampleEnum.Sample2,
    	      CounterName = GetEnumDescription(CounterType.Sample2)
    	    },
    	  }
    	}
      }
    }
