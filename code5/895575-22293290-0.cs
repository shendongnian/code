    while ((sFileContents = srFile.ReadLine()) != null)
      {
           Boolean bMSH_Start = sFileContents.Contains("MSH");
           if (bMSH_Start)
           { 
            //everytime MSH is found, add inner list to outer list
            //init new inner list, add new item to it
            if(innerList != null)
            {
               outerList.Add(innerList);
            }
    
            innerList = new List<string>();
            innerList.Add(sFileContents);
           }
           else
           {
              //if not MSH, then add to inner list
              innerList.Add(sFileContents);
           }
      }
