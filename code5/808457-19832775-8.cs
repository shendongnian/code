       public class CustomResult
        {
            public string output{ get; set; }
            public string cssclass{ get; set; }
        }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static CustomResult lvimgclick()
    {      
        var result=new CustomResult{output="hi", cssclass="lv-under1"}
        
        return result;
    
    }
