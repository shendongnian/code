       var postRequest = (HttpWebRequest)WebRequest.Create(url);                
       postRequest.Method = "GET";
       if (sessionCookie == null)
       {
           postRequest.CookieContainer = new CookieContainer();
       }
       else
       {
           postRequest.CookieContainer = sessionCookie;
       }
       HttpWebResponse postResponse = (HttpWebResponse)await postRequest.GetResponseAsync();
       if (postResponse != null)
       {
           var postResponseStream = postResponse.GetResponseStream();
           var postStreamReader = new StreamReader(postResponseStream);
           string response = await postStreamReader.ReadToEndAsync();
          if (sessionCookie == null)
          {
               sessionCookie = postRequest.CookieContainer;
          }
           return response;
       }
       return null;
    }
            
