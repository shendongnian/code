    var ex = Server.GetLastError();
    var httpException = ex as HttpException ?? ex.InnerException as HttpException;
    if (httpException.WebEventCode == WebEventCodes.RuntimeErrorPostTooLarge)
    {
      Response.Clear();
      Server.ClearError();
      //Do whatever to handle
      return;
    }
