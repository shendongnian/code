    [HttpGet]
    public JsonResult GetClients(//any arguments sent from the client here)
    {
        var clients = //code to get clients
        return Json(new {clients = clients}, JsonRequestBehavior.AllowGet);
    }
