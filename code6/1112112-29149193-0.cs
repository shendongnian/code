    //Remove implicit validations
    foreach (KeyValuePair<string,ModelState> stateItem in ModelState)
    {
    	if (stateItem.Key.Contains("AllocationAmount"))
    	{
    		if (stateItem.Value.Errors.Count > 0 && stateItem.Value.Errors[0].ErrorMessage.Contains("required"))
    		{
    			stateItem.Value.Errors.RemoveAt(0);
    		}
    	}
    }
    
    //Check Validation
    if (!ModelState.IsValid)
    {
    	return PartialView("pvShipment", shipment);
    }
