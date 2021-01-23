    private DateTime startDate;
    public DateTime StartDate
    {
        get 
        {
            return startDate; 
        }
        set
        {
            if (value > EndDate)
            {
                throw new MyEventException("Start date is not supposed to be greater than end date.");
            }
            else
            {
                startDate = value;
            }
        }
    }
    private DateTime endDate;
    public DateTime EndDate
    {
        get 
        { 
            return endDate; 
        }
        set 
        {   
           endDate = value; 
        }
    }
