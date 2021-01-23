    public class CustomComparer : IComparer<string>
    {
    	public int Compare(string x,string y)
        {
        	return CultureInfo.CurrentCulture.CompareInfo.Compare(x, y, CompareOptions.Ordinal);
        }
    }
