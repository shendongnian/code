     public List<TblActivities> SearchByMultipleKeyword(string keywords)
     {
         string[] keywords = pKeywords.Split(',');
     
         var results = Entities.TblActivities.AsQueryable();    
     
         foreach(string k in keywords){
     
             results  = from a in results
                        where a.Keywords.Contains(k)
                        select a;
         }
         return results.ToList();
     }
