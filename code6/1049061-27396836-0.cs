    try
    {
      // Your Code 
    }
    
    catch(Exception wex)
    {
      string pageContent = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd().ToString();
      return pageContent;
    }
     
