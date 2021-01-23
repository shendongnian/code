    private string EncodeParameters()
    {
      var querystring = new StringBuilder();
      foreach (var p in Parameters)
      {
        if (querystring.Length > 1)
    	  querystring.Append("&");
    	
        querystring.AppendFormat("{0}={1}", p.Name.UrlEncode(), p.Value.UrlEncode());
      }
    
      return querystring.ToString();
    }
