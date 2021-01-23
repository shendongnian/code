    // GET api/Test/TestAction/ ...
    [HttpGet]
    public object TestAction(int param1, DateTime startDate, DateTime endDate, 
                             int? param2 = null)
    {
        return new
        {
            param1 = param1,
            param2 = param2,
            startDate = startDate,
            endDate = endDate
        }.ToString();
    }
