    for (i = 0; i<MaxNoOfTimes, i++)
    {   
        int j = getNewValue();
    
        while(orderedList.ContainsKey(j))
        {
            j = getNewValue();
        }
    
        orderedList.Add(j, i);
    }
