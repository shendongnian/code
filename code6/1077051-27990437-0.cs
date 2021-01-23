    try
    {
      using (Stream stream = await MyQuery(parameters))
      using (StreamReader reader = new StreamReader(stream))
      {
        string content = reader.ReadToEnd();
        return content;
      }
    }
    catch (IOException exception)
    {
      if (exception.InnerException is SocketException)
        DoSomething();
      else
        throw;
    }
