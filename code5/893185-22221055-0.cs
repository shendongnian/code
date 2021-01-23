    public System.Web.Http.Results.JsonResult<List<string>> Get()
    {
        int userId = -1;
        List<String> myDevices1 = new List<String>();
        myDevices1.Add("1");
        return Json(myDevices1);   
    }
