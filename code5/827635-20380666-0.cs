    private static List<TestClass> CompareCodes(List<TestClass> list1, List<TestClass> list2)
    {
        List<TestClass> newList ;
    
    	newList	= new List<TestClass>();
        
    	//All the items in list1 that are not in list2 are added
    	foreach (TestClass s in list1)
        {
            if ( ! list2.Contains(s))
            {
                newList.Add(s);
            }
        }        
    	
    	//All the items in list2 that are not in list1 are added
    	foreach (TestClass s in list2)
        {
            if ( ! list1.Contains(s))
            {
                newList.Add(s);
            }
        }        
    
        return newList;
    }
