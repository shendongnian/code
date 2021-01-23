        [WebMethod]
        public string Echo(string input)
        {
           HttpContext ctx = HttpContext.Current;
           string headerValue = ctx.Request.Headers["key"];
        }
