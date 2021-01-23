    public int? ContractYear
    {
        get
        {
            if (Dates.FindIndex((Date d) => d.Type == DateType.Issue) == -1)
                return null;
                
            var firstIssueDate = Dates.First((Date d) => d.Type == DateType.Issue);
            if (firstIssueDate.Year.HasValue)
            {
                return DateTime.Now.Year - 
                       Dates.First((Date d) => d.Type == DateType.Issue).Year.Value;
            }
            else
            {
                return ??? 
                //this is what you need to decide, 
                // what do you want to return when Year is null?
            }
        }
    }
