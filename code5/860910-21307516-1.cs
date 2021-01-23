    object queryResult;
    
    if (check == 1)
    {
    	queryResult = context.SubjectContext
    		.Where(x => x.CreatedBy == CreatedBy)
    		.Select(x => new Student() { Id = x.Id, Name = x.Name });
    }
    else (check == 2)
    {
    	queryResult = context.SubjectContext
    		.Where(x => x.CreatedBy == CreatedBy)
    		.Select(x => new Student() { Id = x.Id, Name = x.Name, Skillset = x.Skillset });
    }
    
    if (queryResult.Any())
    {
    	return jsonRetrunMsg = new JsonReturn { Status = "success", Message = queryResult };
    }
    else
    {
    	return jsonErrorMsg = new JsonError { Status = "error", Message = "Check User Id" };
    }
