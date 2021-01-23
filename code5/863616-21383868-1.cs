    public CrmDateTime CRMFormattedDate(string dateValue)
    {
        CrmDateTime cd = new CrmDateTime();
        string date_str = "";
    
        try
        {
            if (!isValidYear(dateValue.Substring(6, 4)))
                date_str = DateTime.Now.Year.ToString();
            else
                date_str = dateValue.Substring(6, 4);
    
            cd.Value = date_str + "/" + dateValue.Substring(3, 2) + "/" + dateValue.Substring(0, 2) + "T00:00:00";
        }
        catch (Exception ex)
        { 
            cd = null; 
        }
    
        return cd;
    }
    
    private bool isValidYear(string year_value)
    {
        if (Convert.ToInt16(year_value) < 1800)
            return false;
    
        return true;
    }
