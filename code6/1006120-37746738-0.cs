    void Main()
    {
    	var kth = 4;
    	var arr = new int [] {5, 1, 3, 4, 2, 1};
    	var val = getItem(arr, kth);
    	
    }	
    
    int getItem(int[] items, int kth)
    {
    	if (kth == 0 || kth > items.Length)
    	{
    		throw new  IndexOutOfRangeException();
    	}
    	else if (items.Length == 1 && kth == 1)
    	{
            // only 1 item so return it
    		return items[0];
    	}
    	else if (items.Length == 2)
    	{
    		if (kth ==1)
    		{
                // two items, 1st required so return smallest   
    			return (items[0] <= items[1] ? items[0] : items[1]);
    		}
    		else
    		{
                // two items, 2nd required so return smallest   
    			return (items[0] <= items[1] ? items[1] : items[0]);
    		}
    	}
    	var middleItem = (int)((items.Length)/2);
    	var pivot = items[middleItem];
    
    	var leftarr = items.Where(s => s < pivot).ToArray();
    	if (leftarr.Length + 1 == kth)
    	{
    		//our pivot is the item we want
    		return pivot;
    	}
    	else if (leftarr.Length >= kth)
    	{
    		// our item is in this array
    		return getItem(leftarr, kth);
    	}
    	else
    	{
            // need to look in the right array
    		var rightarr = items.Where(s => s >= pivot).ToArray();
    		if (rightarr.Length == 0)
    		{
    			return pivot;
    		}
    		return getItem(rightarr, kth - leftarr.Length);
    	}
    }
