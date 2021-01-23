    public void SetCulture(string language)
    {
    	if (language == "sv-SE")
    	{
    		Session["CultureValue"] = new CultureInfo("sv-SE", false);
    	}
    
    	if (language == "en-US")
    	{
    		Session["CultureValue"] = new CultureInfo("en-US", false);
    	}
    }
