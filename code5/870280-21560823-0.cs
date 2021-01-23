    public PropertyEvidenceBL()
    {
        CheckFirstName();
    }
    private string CheckFirstName()
    {	
       if (FirstPersonName == string.empty)
       {
	       return LocationName;
       }
       else
       {
	      return FirstPersonName
       }		
    }
