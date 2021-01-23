    Dictionary<string, Dictionary<string, Dictionary<string, string>>> dict= new Dictionary<string, Dictionary<string, Dictionary<string, string>>>(); 
     if (dict.ContainsKey(outerKey))
     {
       var innerDict = dict[outerKey];
       if (innerDict.ContainsKey(innerKey))
       {  
           var innerMost = innerDict[innerKey];
           if (innerMost.ContainsKey(innerMostKey))
            var item = innerMost[innerMostKey]; // This is the item of inner most dict
        }
     }
