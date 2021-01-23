              string sPath = (HttpContext.Current.Request.Url).ToString();
              sPath = sPath.Replace("http://", "");
              System.IO.FileInfo oInfo = new  System.IO.FileInfo(HttpContext.Current.Request.RawUrl);
              string sRet = oInfo.Name;
              Response.Write(sPath.Replace(sRet, ""));
