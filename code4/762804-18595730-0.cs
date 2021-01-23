    public ActionResult Index(int? month, int? year)
    {
        int noOfDaysInMonth = -1;
        if(year.HasValue && year.Value > 0 && 
                month.HasValue && month.Value > 0 && month.Value <=12)
        {
            noOfDaysInMonth = DateTime.DaysInMonth(year.Value, month.Value);
        } 
        else
        {
            // parameters weren't there or they had wrong values
            // i.e. month = 15 or year = -5 ... nope!
            noOfDaysInMonth = -1; // not as redundant as it seems...
        }
    
        // rest of code.
    }
