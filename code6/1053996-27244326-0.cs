    private long DeleteUser(long UserID)
    {
        using(VerbaTrackEntities dataContext = new VerbaTrackEntities())
        {
            TBL_USER user = dataContext.TBL_USER.
                                     SingleOrDefault(x => x.LNG_USER_ID == UserID);
            if(user != null)
            {       
                dataContext.TBL_USER.Remove(user); 
                dataContext.SaveChanges();
            }
        }
        return 0;
    }
  
