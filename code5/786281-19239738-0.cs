    string aspxurl = string.Empty;
    string querystring = string.Empty;
    string[] strTmpQuery = System.Web.HttpContext.Current.Request.RawUrl.Split('?');
    if(strTmpQuery[0].Endswith(".php"))
    {
      aspxurl = strTmpQuery[0].Substring(0,strTmpQuery[0].Length-4) + ".aspx";
    }
    
    if(strTmpQuery.Length>1 && strTmpQuery[1].Trim() != "")
    {
    querystring = strTmpQuery[1];
    }
    System.Web.HttpContext.Current.RewritePath(aspxurl, "", querystring);
