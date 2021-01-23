    var wind1250 = Encoding.GetEncoding(1250);
    
  
    var querystring = HttpUtility.UrlDecode(Request.Url.Query, wind1250);//;    
    var qs = HttpUtility.ParseQueryString(querystring);
    Response.Write(qs["Where"]);
