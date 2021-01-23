    [WebService(Namespace = "http://...")]
    [System.Web.Script.Services.ScriptService]
    public class MYWS
    {
    	[WebMethod]
            [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
            public string JSONMethod(/*ParType ParName, ParType ParName2,.. etc*/)
            {
                    List<object> tempobjects = new List<object>();
                    tempobjects.Add(new { ID = id, Val = val /*more params=> ParName= "ParValue", etc..*/ });
    
                    var retVal = new JavaScriptSerializer().Serialize(tempobjects.ToArray());
    
                    Context.Response.ContentType = "application/json";
                    var p = "";
                    if (Context.Request.Params.AllKeys.Contains("callback") == true)
                        p = Context.Request.Params["callback"].ToString();
    		Context.Response.Write(string.Format(CultureInfo.InvariantCulture, "{0}({1})", p, retVal));
            }
    }
