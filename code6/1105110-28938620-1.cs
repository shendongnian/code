    static void Main(string[] args)
    {
         using(var persistenceManager = new NHibernateBaseRepository())
         {
             ROLE f = persistenceManager.GetById<ROLE>(34);
    
    	     f.RoleComment = "Test Com";
    	     f.HIERARCHY.CHANGETIME = DateTime.Now; //Throws error
    	     persistenceManager.SaveOrUpdateEntitiy<ROLE>(f);
         }
    }
