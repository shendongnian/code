    int i = 0;
    string val = string.Empty;
    foreach (string strValue in strArray)
    {
    	val += strValue + "  ";
    	i++;
    	if (i == 2)
    	{
    		listView1.Items.Add(val);
    		i = 0;
    		val = string.Empty;
    	}
      
    }
