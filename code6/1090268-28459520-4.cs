     private void getSessionVariables()
    {
      Dictionary<string, string> sessionData = new Dictionary<string, string>();
      // Retrieve Session that is stored in dictionary
      Dictionary<string, List<string>> sessionDict =
        _context.Session["jsPass"] as Dictionary<string, List<string>>;
      if (sessionDict != null)
      {
        foreach (KeyValuePair<string, List<string>> entry in sessionDict)
        {
          // Set the Value of the item
          foreach (string value in entry.Value)
          {
            sessionData.Add(entry.Key, value.ToString());
          }
        }
     }
     // _context is just my private HttpContext variable I set at the beginning of the class
     utility.httpContentWrite(_context, sessionData); 
    }
