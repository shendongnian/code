    [WebMethod]
    public static string lvimgclick()
    {      
        var result=new {output="hi", cssclass="lv-under1"}
        System.Web.Script.Serialization.JavaScriptSerializer 
        srzlr=new System.Web.Script.Serialization.JavaScriptSerializer();
        Response.ContentType="application/json";
        return srzlr.Serialize(result);
    
    }
