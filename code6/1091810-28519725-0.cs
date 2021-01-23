      public void Modify(Region r, List<BctGouvernorat> _ToUnlink, List<BctGouvernorat> _ToLink)
       {
       _ToLink.All(xx =>
           {
               xx.RegionId = r.RegionId;
               xx.Region = r;
               _uow.GetEntry<BctGouvernorat>(xx).State = EntityState.Modified;
               r.Gouvernorats.Add(xx);
               return true;
           });
           //The parent entity must be marked as modified here : 
           //  after adding new items but before removing items from collection
          
      _uow.GetEntry<Region>(r).State = EntityState.Modified;
            
          
           if (_ToUnlink.Count > 0)
           {
              r.Gouvernorats.ToList().All(xx =>
                   {
                       if (_ToUnlink.Contains(xx))
                       {
                           xx.RegionId = null;
                           xx.Region = null;
                       }
                       
                       return true;
                   }
               );
            }
         
             base.Modify(r);
       }
