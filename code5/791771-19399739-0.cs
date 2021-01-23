    while (!processStarted && DateTime.Now < timeout)
    {
       try
       {
          request.GetResponse();
          processStarted = true;
       }
          catch (WebException)
       {
    }
