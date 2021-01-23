    [WebMethod]
    GetXXX(string param1, string param2)
    {
        var request = new GetXXXRequest(param1, param2);
        return _webServiceHandler.Execute(() => _controller.GetXXX(request)
                                          new Parameter("param1", param1),
                                          new Parameter("param2", param2));
    }
