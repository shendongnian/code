    public async Task<IHttpActionResult> Update(TeamBindingViewModel model)
    {
        // If our model is invalid, return the errors
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
    
        // Get our current team
        var team = await this.service.GetAsync(model.Id, "Colours");
    
        // Make changes to our team
        team.Name = model.Name;
        team.Sport = model.Sport;
    
        //remove
	    foreach (var colour in team.Colours.ToList())
    	{
    		if (!model.Colours.Any(c => c.Id == colour.Id))
	    		team.Colours.Remove(colour);
    	}
	
    	//add
	    foreach (var colour in model.Colours)
    	{
    		if (!team.Colours.Any(c => c.Id == colour.Id))
    			team.Colours.Add(colour);
    	}
        
        // Update the team
        this.service.Update(team);
        
        // Save the database changes
        await this.unitOfWork.SaveChangesAsync();
        
        // Return Ok
        return Ok(model);
    }
