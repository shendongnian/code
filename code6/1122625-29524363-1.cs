    public class Executor
    { 
    	ParallelOptions Options = new ParallelOptions() { MaxDegreeOfParallelism = 4 };
        
        IList<Step> AllSteps;
    
    	//concurrent hashset of remaining steps (used to prevent race conditions)
        ConcurentDictionary<Step, Step> RemainingSteps = new ConcurentDictionary<Step, Step>();
    
        //blocking collection of steps that can execute next
        BlockingCollection<Step> ExecutionQueue = new BlockingCollection<Step>();
    
        public void Execute()
        {
            foreach(var step in AllSteps)
            {
            	if(step.Parents.All(p => p.IsComplete))
            	{
            		ExecutionQueue.Add(step);
            	}
            	else
            	{
            		RemainingSteps.Add(step, step);
            	}
            }
    
            Parallel.ForEach(
            	GetConsumingPartitioner(ExecutionQueue),
    			Options,
    			Execute);
        }
    
        void Execute(Step step)
        {
            ExecuteStep(step);
    
            if(RemainingSteps.IsEmpty)
            {
            	//we're done, all steps are complete
            	executionQueue.CompleteAdding();
            	return;
            }
    
            //queue up the steps that can execute next (concurrent dictionary enumeration returns a copy, so subsequent removal is safe)
            foreach(var step in RemainingSteps.Values.Where(s => s.Parents.All(p => p.IsComplete)))
            {
            	//note, removal only occurs once, so this elimiates the race condition
            	Step NextStep;
            	if(RemainingSteps.TryRemove(step, out NextStep))
            	{
    	        	executionQueue.Add(NextStep);
    	        }
            }
        }
    
    	Partitioner<T> GetConsumingPartitioner<T>(BlockingCollection<T> collection)
    	{
    	    return new BlockingCollectionPartitioner<T>(collection);
    	}
    	 
    	class BlockingCollectionPartitioner<T> : Partitioner<T>
    	{
    	    readonly BlockingCollection<T> Collection;
    	 
    	    public BlockingCollectionPartitioner(BlockingCollection<T> collection)
    	    {
    	        if (collection == null) throw new ArgumentNullException("collection");
    	        
    	        Collection = collection;
    	    }
    	 
    	    public override bool SupportsDynamicPartitions { get { return true; } }
    	 
    	    public override IList<IEnumerator<T>> GetPartitions(int partitionCount)
    	    {
    	        if (partitionCount < 1) throw new ArgumentOutOfRangeException("partitionCount");
    
    	        var Enumerable = GetDynamicPartitions();
    
    	        return Enumerable.Range(0, partitionCount)
    	        				 .Select(i => Enumerable.GetEnumerator()).ToList();
    	    }
    	 
    	    public override IEnumerable<T> GetDynamicPartitions()
    	    {
    	        return Collection.GetConsumingEnumerable();
    	    }
    	}
    }
