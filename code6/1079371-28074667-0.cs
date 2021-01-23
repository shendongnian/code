    protected List<string> Results = new List<string>();
    void GetPermutations(string s)
    {
    	Results = new List<string>();
    	string[] values = s.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    	GetPermutationsRecursive(String.Empty, values, 0);
    }
    void GetPermutationsRecursive(string soFar, string[] values, int index)
    {
	    if (index < values.Length)
	    {
		    foreach (var y in GetVariations(values[index]))
    		{
	    		string s = String.Format("{0}{1}{2}", soFar, soFar.Length > 0 ? "," : String.Empty, y);
		    	GetPermutationsRecursive(s, values, index + 1);
		    }
	    }
    	else
	    {
		    Results.Add(soFar);
	    }
    }
    IEnumerable<string> GetVariations(string s)
    {
	    int pos = s.IndexOf('|');
	    if (pos < 0)
	    {
	    	yield return s;
	    }
	    else
    	{
	    	yield return s.Substring(0, pos);
	    	yield return s.Substring(pos + 1);
	    }
    }
