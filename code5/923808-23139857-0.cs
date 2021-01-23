    List<int> arrCMs = new List<int>();
    foreach (string str in strMyList.Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries))
    {
    	int res;
    	if (int.TryParse(str, out res))
    	{
    		arrCMs.Add(res);
    	}
    }    
