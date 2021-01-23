     string secondDictionaryKey = "";
     string secondDictionaryValue = "";
     foreach (int key in levelProgress.Keys)
     {
         Dictionary<string, int> storedDictionary;
         if (!levelProgress.TryGetValue(key, out storedDictionary))
             continue;
         foreach(string k in storedDictionary.Keys)
         {
             secondDictionaryKey = k;
             secondDictionaryValue = storedDictionary[k];
             break;
         }
         
         break;               
         
     }
