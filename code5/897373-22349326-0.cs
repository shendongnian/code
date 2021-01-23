    void AddToYourCustomDictionary(int someValue)
    {
       if(dic[1] != null)
       {
          dic.Add(1, new List<int>());
           dic[1].Add(someValue);
       }
       else  
         dic[1].Add(someValue); //Adding element in existing key Value pair
     }
