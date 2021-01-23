    public ActionResult GetNavFromDatabase() {
      
       var navs = dbcontext.Nav.ToList();
       var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
       return oSerializer.Serialize(navs);
   
    }
