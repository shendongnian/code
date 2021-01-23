    int maxLength = 0;
    
    foreach(string s in array)
    {
        l = s.Trim().Length;
    	if (l > maxLength)
    	{
    		maxLength = l;
    	}
    }
    
    foreach(string s in array)
    {
    	emailBody += System.Format("{0,-" + maxLength.ToString() + "}    |    Success" + Environment.NewLine, s.Trim());
    }
