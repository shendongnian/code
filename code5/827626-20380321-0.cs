        private static List<TestClass> CompareCodes(List<TestClass> list1, List<TestClass> list2)
    {
        List<TestClass> newList = new List<TestClass>();
         bool found = false; 
        foreach (TestClass s in list2)
        {
                foreach (TestClass1 s in list1)
        {
            if(TestClass.TestString==TestClass&.TestString )
             { 
                found = true; 
                break; 
             }
        } 
         if(!found)
          newList.Add(testclass);     
             
        }        
    
        if (newList != null)
            return newList;
        else
            return null;
    }
