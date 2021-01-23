    private static string GetFacebookUserJSON(string access_token)
    {
        try
        {
          string url = string.Format("https://graph.facebook.com/me?access_token={0}&fields=email,name,first_name,last_name,link", access_token);
    
          WebClient wc = new WebClient();
          Stream data = wc.OpenRead(url);
          StreamReader reader = new StreamReader(data);
          string s = reader.ReadToEnd();
          data.Close();
          reader.Close();
    
          return s;
        }
        
        catch (WebException wex)
        {
            string pageContent = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd().ToString();
            return pageContent;
         }
    }
