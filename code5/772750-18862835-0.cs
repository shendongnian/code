    <input id="responsable" value="True" name="checkResp" type="checkbox" /> 
    [HttpPost]
    public ActionResult Index(FormCollection collection)
    {
         if(!string.IsNullOrEmpty(collection["checkResp"])
         {
            string checkResp=collection["checkResp"];
            bool checkRespB=Convert.ToBoolean(checkResp);
         }
    
    }
