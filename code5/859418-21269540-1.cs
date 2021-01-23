    public class some_generic_handler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string myVar = "";
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["myVar"])) { myVar = System.Web.HttpContext.Current.Request.Form["myVar"].Trim(); }
            var myArr = JsonConvert.DeserializeObject<List<List<string>>>(myVar);
            string firstElement = myArr[0][0];
            string response = String.Format(@"{{ ""success"" : true, ""message"" : ""Cool! We're done."", ""firstElement"" : ""{0}"" }}", firstElement);
            context.Response.ContentType = "application/json";
            context.Response.Write(response);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
