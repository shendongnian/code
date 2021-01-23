    try
    {
       using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
       {
          WebHeaderCollection headers = response.Headers;    
          using (Stream Answer = response.GetResponseStream())
          {
              // Do stuff
          }
       }
    }
    catch (WebException e)
    {
       if (e.Status == WebExceptionStatus.Timeout)
       {
          // Handle timeout exception
       }
    }
