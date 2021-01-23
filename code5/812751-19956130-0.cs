    public IEnumerable GetCrewMember()
    {
         SASEntities db = DataContextFactory.GetSASEntitiesDataContext();
     
         return (from cm in db.CrewMember
                 select new 
                 {
                      CompleteName = cm.LastName + "," 
                                      + cm.FirstName +" "
                                      + cm.FullName
                 }).ToList();
    }
