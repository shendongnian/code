    public SpaceResult<IEntity> SelectList() 
    {
    	SpaceResult<IEntity> result = new SpaceResult<IEntity>();
    
    	try
    	{
    		result.SelectList = this.GetAll().Select(x => new SelectListItem { x.Id, x.Name });
    	}
    	catch (System.Exception ex)
    	{
    		result.IsError = true;
    		result.Message = ex.Message;
    		result.InnerException = ex.InnerException.Message;
    	}
    
    	return result;
    }
