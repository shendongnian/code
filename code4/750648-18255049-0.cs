    foreach (var eve in ex.EntityValidationErrors)
    {
		//New Details Entity
		var errorDetail = new HttpStatusErrorDetails();
		
		//Fill in Header
        errorDetail.Header = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            eve.Entry.Entity.GetType().Name, eve.Entry.State);
			
		//Fill Add a detail for each validation error
		foreach (var ve in eve.ValidationErrors)
        {
			errorDetail.Details.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                ve.PropertyName, ve.ErrorMessage));
        }
		
		//Add Detail to header
		msg.Details.Add(errorDetail);
    }
