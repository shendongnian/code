    void Main()
    {	            
    	  var hashSet1 = new HashSet<int>();
    	  hashSet1.Add(1);
    	  hashSet1.Add(2);
    	  hashSet1.Add(3);
    	  hashSet1.Add(4);
    	  hashSet1.Add(5);
    	  
    	  var hashSet2 = new HashSet<int>();
    	  hashSet2.Add(6);
    	  hashSet2.Add(7);
    	  hashSet2.Add(8);
    	  hashSet2.Add(9);
    	  hashSet2.Add(0);
    	
    	SwapHashSets(hashSet1, hashSet2, 3);	
    }
    
    
    private List<int> GetXValuesFromHashSet(HashSet<int> hashSet, int count)
    {
      var list = new List<int>();
    
      for (var i = 0; i < count; i++)
      {
          list.Add(hashSet.ElementAt(i));
      }
    
      return list;
    }
    	
    private void SwapHashSets(HashSet<int> hashSet1, HashSet<int> hashSet2, int count )
    {
      var list1 = GetXValuesFromHashSet(hashSet1, count);
      var list2 = GetXValuesFromHashSet(hashSet2, count);
    
      foreach (var value in list1)
      {
          hashSet1.Remove(value);
      }
    
      foreach (var value in list2)
      {
          hashSet2.Remove(value);
      }
      foreach (var value in list1)
      {
          hashSet2.Add(value);
      }
    
      foreach (var value in list2)
      {
          hashSet1.Add(value);
      }
      
    }
	
