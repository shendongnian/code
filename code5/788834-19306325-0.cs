    class YourClass
    {
       private readeonly WebService _ws;
       public YourClass(WebService ws)
       {
           _ws=ws;
       }
       [HttpPost]
       public JsonResult GetUserListFromWebService()
       {
           JsonResult jsonResult = new JsonResult();
           jsonResult.Data = _ws.GetUserList(User.Identity.Name);
           return jsonResult;
       }
    }
