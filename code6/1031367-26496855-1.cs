        public static void loopAllEntities(DbContext dbContext)
        {
            List<Type> modelListSorted = ModelHelper.ModelListSorted();
        
            foreach (Type type in modelListSorted) 
            {
                var records = dbContext.Set(type);
	    		// do something with the set here
            }
        }
