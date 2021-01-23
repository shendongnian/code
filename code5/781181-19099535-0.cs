    public bool CheckAD()
    {	
    	try	{...}
    	catch
    	{
    		if (fncADStatus == fncFailure)
    		{
    			logger.Debug("One");
    		}
    		if (Session["SessionADStatus"] == null)
    		{
    			logger.Debug("Two");
    		}
    		
    		return false; // <<<<< This bit is missing in your case
    	}
    }
