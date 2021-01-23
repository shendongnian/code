    public class RTBTextPointer
    {
    	public int Row
    	{
    		get;
    		set;
    	}
    	public int Column
    	{
    		get;
    		set;
    	}
    	public override bool Equals(object obj)
    	{
    		if (ReferenceEquals(null, obj))
    		{
    			return false;
    		}
    		if (ReferenceEquals(this, obj))
    		{
    			return true;
    		}
    		var other = obj as RTBTextPointer;
    		if (other == null)
    		{
    			return false;
    		}
    		return other.Row == Row && other.Column == Column;
    	}
    	public override int GetHashCode()
    	{
    		unchecked
    		{
    			// 397 or some other prime number
    			return (Row * 397) ^ Column;
    		}
    	}
    }
