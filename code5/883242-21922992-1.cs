    public class WebService1 : System.Web.Services.WebService
        {
            [WebMethod]
            [ScriptMethod(UseHttpGet=true ,ResponseFormat = ResponseFormat.Json)]
            public void HelloWorld()
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";           
                HelloWorldData data = new HelloWorldData();
                data.Message = "HelloWorld";
                 Context.Response.Write(js.Serialize(data));
    
    
            }
        }
    
        public class HelloWorldData
        {
           public String Message;
        }
