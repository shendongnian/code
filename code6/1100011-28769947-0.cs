    public ActionResult Index()
    {
        try
        {
            var a = Convert.ToInt64("");
        }
        catch (YourExceptionType ex)
        {
           // Do something
        }
    
        return view();
    }
