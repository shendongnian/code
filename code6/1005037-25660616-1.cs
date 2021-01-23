    var list2 = new List<KeyValuePair<string, int>>();
    
         for (int i=0;i<list.Count-1;i++)
        {
           if (list[i].Value>list[i+1].Value)
            {         
              list2.Add(new KeyValuePair<string, int>(list[i].Key,list[i].Value)
            }
        }
