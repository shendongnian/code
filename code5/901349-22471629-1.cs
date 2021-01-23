    public static List<table1> CRBTsongformis(string sSname)
    {
        List<table1> crbtlist = new List<table1>();
        using (crbt_onwebEntities dbContext = new crbt_onwebEntities())
        {
            crbtlist = (from z in dbContext.table1 
                        where z.CONTENT_NAME==sSname && 
                        z.STATUS!=null select z).ToList();
        }
        return crbtlist;
    }
