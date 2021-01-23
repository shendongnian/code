    var dispRes = new DisposeResult();
    ... 
    try
    {
      .. the following could be in some nested routine which took dispRes as a parameter
      using (dispWrap = new DisposeWrap(dispRes, ... other disposable resources)
      {
        ...
      }
    }
    catch (...)
    {
    }
    finally
    {
    }
    if (dispRes.Exception != null)
      ... handle cleanup failures here
