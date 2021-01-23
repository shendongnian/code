    try 
    {
      using(var response = (HttpWebResponse)request.GetResponse())
      {
        // Do things
      }
    }
    catch(WebException e)
    {
       // Handled!...
    }
