    [HttpPost]
    public JsonResult GetTimeStamp()
    {
       string time_stamp = DateTime.Now.ToString("o");
       return Json(time_stamp);
    }
