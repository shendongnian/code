    private class MyResponseObject
    {
      public string Data = string.Empty;
      // Alternatively you could return the HttpResponseMessage (I guess).
      //public HttpResponseMessage HttpResponseMessage;
      
      public Exception Exception = null;
    }
