    List<string> list= new List<string>();
    
    for (int i =0 ; i< list.Count(); i++)
    {
       for(int k = 0 ; k< list.Count(); k++)
       {
         if(list[i] == list[k])
         {
            list.RemoveAt(k);
             or do something ....///
         }
       }
    }
