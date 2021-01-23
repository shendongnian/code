    public int checkComRegnumberAvailable(string conRegnumber)
    {       
        List<OtherCompany> checklist = getCompanyDetails();
    
        foreach (var listItem in checklist)
        { 
            if (listItem.RegNumber == conRegnumber)
            {
                return 1;
            }
        }
    
        return 0; 
    }
