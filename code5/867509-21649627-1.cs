    //StoredProcedure.cs line 104-112
    private string FixProcedureName(string name)
    {
    	string[] parts = name.Split('.');
    	for (int i = 0; i < parts.Length; i++)
    		if (!parts[i].StartsWith("`", StringComparison.Ordinal))
    			parts[i] = String.Format("`{0}`", parts[i]);
    	if (parts.Length == 1) return parts[0];
    	return String.Format("{0}.{1}", parts[0], parts[1]);
    }
