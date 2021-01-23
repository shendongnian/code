    var serviceProxy = new ServiceProxy();
    try 
    {
        var dataObj = serviceProxy.GetObj();
    }
    catch (FaultException<ErrorResponseObj> error)
    {
        ErrorResponseObj detail = error.Detail;
        Console.WriteLine(detail.ErrorMessage);
    }
