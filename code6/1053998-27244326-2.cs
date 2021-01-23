    private long DeleteUser(long UserID)
    {
        using(VerbaTrackEntities dataContext = new VerbaTrackEntities())
        {
            TBL_USER user = dataContext.TBL_USER
                                 .SingleOrDefault(x => x.LNG_USER_ID == UserID);
            if(user != null)
            {
                foreach (var cases in user.TBL_USER_CASE.ToList())
                {
                    //little modification is here
                    dataContext.TBL_USER_CASE.Remove(cases);                          
                }
            }
            dataContext.SaveChanges();
        }
        return 0;
    }
