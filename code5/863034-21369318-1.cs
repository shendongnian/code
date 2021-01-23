    public class Pair : IComparable<Pair>
    {
        public int First { get; private set; }
        public int Second { get; private set; }
    	
    	public Pair(int first, int second)
    	{
    		this.First = first;
    		this.Second = second;
    	}
    	
    	public int CompareTo(Pair other)
        {
            if (other != null)
                return this.First.CompareTo(other.First);
            else
                return 1;
        }
    }
