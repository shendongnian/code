    var acctNos = new List<int>() { 0,1,2,4,20,21,22 };
    var unusedAcctNos = Enumerable.Range(0, 10000).Except(acctNos).ToList();
    StringBuilder builder = new StringBuilder();
    int lastNo = unusedAcctNos.Last();
    int previousVal = -2;
    bool isRange = false;
    foreach (int i in unusedAcctNos)
    {
    	if (i == previousVal + 1 && i != lastNo) //is in range
    	{
    		previousVal = i;
    		isRange = true;
    		continue;
    	}
    	else if (previousVal > -1) //range broke
    	{
    		if (isRange)
    		{
    			builder.Append("-");
    			if (i == lastNo && previousVal == i - 1)
    			{
    				builder.Append(i);
    				break;
    			}
    			else
    			{
    				builder.Append(previousVal);
    			}
    			isRange = false;
    		}
    					
    		builder.Append(",");//change group splitter here
    	}
    
    	builder.Append(i);
    
    	previousVal = i;
    }
