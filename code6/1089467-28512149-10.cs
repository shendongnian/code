    public virtual ActionResult Index()
    {
        try
        {
            return View();
        }
        catch (Exception e)
        {
            throw new MyException("detailed exception", e);
        }
    }
