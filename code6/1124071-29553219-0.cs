    string ido = "433, 045, 3-3-15, 444, 0.6,3.9,4,5,5,4,3,3"; 
    
    string[] sn= ido.Split(new char[]{','}, 13, StringSplitOptions.RemoveEmptyEntries);
    
    ArrayList list = new ArrayList();
    foreach (string str in sn)
    {
    	string trimmedStr = str.Trim();
    	float f;
    	if (float.TryParse(trimmedStr, out f))
    	{
    		list.Add(f);
    	}
    	else if (trimmedStr.Contains("-"))
    	{
    		ArrayList list2 = new ArrayList();
    		foreach (string str2 in trimmedStr.Split(new char[]{'-'}, StringSplitOptions.RemoveEmptyEntries))
    		{
    			string trimmedStr2 = str2.Trim();
    			if (float.TryParse(trimmedStr2, out f))
    			{
    				list2.Add(f);
    			}
    		}
    		list.Add(list2.ToArray());
    	}
    }
    
    object[] array = list.ToArray();
