    try 
    {
    	applicationDbContext.SaveChanges();
    	return RedirectToAction("Index");
    }
    catch (DbUpdateException e) {
    	var sqlException = e.GetBaseException() as SqlException;
    	if (sqlException != null) {
    		if (sqlException .Errors.Count > 0) {
    			switch (sqlException .Errors[0].Number) {
    				case 547: // Foreign Key violation
    					ModelState.AddModelError("CodeInUse", "Country code could not be deleted, because it is in use");
    					return View(viewModel.First());
    				default: 
    					throw;      
    			}
    		}
    	}
        else {
           throw;
    	}                
    }
