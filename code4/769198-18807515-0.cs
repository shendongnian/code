    public IEnumerable<MyObj3> GetMyObJects3()
    {            
        using(MyEntities entities = new MyEntities())
        {
    	    ObjectResult<SPResult> Results = entities.GetMyObJects3();
    	    IEnumerable<MyObj3> results = Results.ToList();
    		
            return results;
        }
    }
