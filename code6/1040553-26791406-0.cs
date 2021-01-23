    public List<myModel> Get()
    {
        using (var db = new myEntities())
        {
            return db.Images.OrderBy(x => x.Id==1).ToList()
    			.Select(x => new myModel
    	        {
        	        Id = x.Id,
            	    Name = x.Name,
                	Bytes = x.Bytes,        
    	            BytesToFloat = (IEnumerable<float>)x.Bytes.Cast<float>()
        	    }).ToList();
            	
        }
    }
