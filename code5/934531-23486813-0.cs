    public class SelectedItemComparer : IEqualityComparer<Part>
    {
    
    	public new bool Equals(Part x, Part y)
    	{
    		return x.Id == y.Id;
    	}
    
    	public int GetHashCode(Part source)
    	{
    		string code = source.Id.ToString();
    
    		return code.GetHashCode();
    
    	}
    }
