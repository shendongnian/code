    public IEnumerable<string> MyFunc(string searchString)
    {
        return myThingToSearch.Where(x => LevenshteinDistance(x, searchString) <= 1);
    }
    public static int LevenshteinDistance(string s1, string s2)
    {
	    if (s1 == s2)
	    {
		    return 0;
	    }
	    if (s1.Length == 0)
	    {
		    return s2.Length;
	    }
	    if (s2.Length == 0)
	    {
		    return s1.Length;
	    }
	    int[] v0 = new int[s2.Length + 1];
	    int[] v1 = new int[s2.Length + 1];
	    for (int i = 0; i < v0.Length; i++)
	    {
		    v0[i] = i;
	    }
	    for (int i = 0; i < s1.Length; i++)
	    {
		    v1[0] = i + 1;
		    for (int j = 0; j < s2.Length; j++)
		    {
			    var cost = (s1[i] == s2[j]) ? 0 : 1;
			    v1[j + 1] = Math.Min(v1[j] + 1, Math.Min(v0[j + 1] + 1, v0[j] + cost));
		    }
		    for (int j = 0; j < v0.Length; j++)
		    {
			    v0[j] = v1[j];
		    }
	    }
	    return v1[s2.Length];
    }
