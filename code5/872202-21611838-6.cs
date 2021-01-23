    [HttpPost]
    public ActionResult PostMethod()
    {
       System.Threading.Thread.Sleep(1000);
       return View(); 
       //assuming you have the PostMethod.cshtml 
       //present in ~/Views/YourControllerName`directory
    }
