    public class MeetingComparer : IEqualityComparer<Meeting>
    {
    	public bool Equals (Meeting x, Meeting y)
    	{
    		return x.smth.Equals (y.smth);
    	}
    
    	public int GetHashCode (Meeting obj)
    	{
    		return obj.smth.GetHashCode ();
    	}
    }
