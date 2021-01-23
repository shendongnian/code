    public int? ContractYear
    {
        get
        {
            var firstIssueDate = Dates.FirstOrDefault((Date d) => d.Type == DateType.Issue);
            if (firstIssueDate == null)
            {
                return null;
            }
            else if (firstIssueDate.Year.HasValue)
            {
                return DateTime.Now.Year - firstIssueDate .Year.Value;
            }
            else
            {
                return ??? 
                //this is what you need to decide, 
                // what do you want to return when Year is null?
            }
        }
    }
