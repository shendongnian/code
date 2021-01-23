    public abstract class WorkStatus : IComparable<WorkStatus> {
        public abstract int Order { get; } 
    	
    	public int CompareTo(WorkStatus w)
    	{
    		if(w.Order < this.Order)
    		 return 1;
    		if(w.Order > this.Order)
    		 return -1;
    		return 0;
    	}
    }
    
