    [HttpPost]
    public ActionResult PostMethod()
    {
        try
        {
            System.Threading.Thread.Sleep(1000);
            return Json( new { Status="Success"});
        }
        catch(Exception ex)
        {
           //log error
           return Json( new { Status="Error"});
        }
    }
