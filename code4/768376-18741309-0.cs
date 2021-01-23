    var combined = new List<Tuple<int,int.int>>()
    for(int i=0; i<categoryList.Count(); i++)
    {
     var e = categoryList[i];
     var dicKeys = ProductIdQuantityDictionary.Keys;
     if(i < dicKeys.Count()){
     combined.Add(new Tuple(e,dicKeys[i],ProductIdQuantityDictionary[dicKeys[i]]))
     }
     else
     {
      combined.Add(new Tuple(e,0,0))
     }
    }
