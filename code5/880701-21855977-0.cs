            var uriBuilder = new UriBuilder(Request.Url.AbsoluteUri);
            var paramValues = HttpUtility.ParseQueryString(uriBuilder.Query);
            paramValues.Add("param1", "value1");
            paramValues.Add("param2", "value2");
            uriBuilder.Query = paramValues.ToString();
   
            Link1.HRef=uriBuilder.Uri;
