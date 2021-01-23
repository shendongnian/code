    private static List<TestClass> CompareCodes(List<TestClass> list1,
        List<TestClass> list2)
    {
        List<TestClass> newList = new List<TestClass>();
        bool found = false; 
        foreach (TestClass s in list2)
        {
            foreach (TestClass t in list1)
            {   
               //let's say that teststring is your object id / key 
                if(s.TestString==t.TestString )
                { 
                    found = true; 
                    break; 
                }
            }
            if(!found)         
                newList.Add(testclass);               
           found=false;  
       }
       if (newList != null)
           return newList;
       else
           return null;
    }
