    List<Exception> exceptions = new List<Exception>();
    foreach (var transaction in transactions)
    {
       try
       {
          string result = webservice.Call(transaction);
          if result == "Faild"
          {
              // log some errors.
          }
        }
        catch (Exception ex)
        {
           exceptions.Add(ex);
        }
    }
    
    if (exceptions.Any())
        throw new AggregateException(exceptions);
