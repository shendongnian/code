    You can use like this..
    
    [NoCache]
    public ActionResult Ex()
    {
        //enter code here
    }
    
    or
    
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")] 
    public ActionResult Ex()
    {
       //enter code here
    }
    
    Hope it helps...
